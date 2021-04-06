using FATIApp.Models.Fati;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace FATIApp.Controllers
{
    public class FatiController : Controller
    {

        private string baseURL = "https://api.nexon.co.kr/fifaonline4/v1.0/";
        private string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2NvdW50X2lkIjoiMTYyNzg1NDg3OCIsImF1dGhfaWQiOiIyIiwidG9rZW5fdHlwZSI6IkFjY2Vzc1Rva2VuIiwic2VydmljZV9pZCI6IjQzMDAxMTQ4MSIsIlgtQXBwLVJhdGUtTGltaXQiOiI1MDA6MTAiLCJuYmYiOjE2MTYzNzIxNDIsImV4cCI6MTYzMTkyNDE0MiwiaWF0IjoxNjE2MzcyMTQyfQ.z6aortdCl27XuUx-XWG7YwxRyk5iwiYkiPBZUYGToys";
        private readonly ILogger<FatiController> _logger;
        public FatiController(ILogger<FatiController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            _logger.LogWarning("pass");
            return View();
        }

        public IActionResult Search(string nickName)
        {
            Console.WriteLine(nickName);
            //유저 아이디 반환
            string accessId = getAccessID(nickName);
            List<string> matches = getMatches(accessId);
            
            
      

            List<string> nickNames = new List<string>();
           
            return View(nickNames);
        }

    

        //유저 닉네임을 사용해 유저 아이디 반환
        public string getAccessID(string nickName)
        {
            string url = baseURL + "users?nickname=" + nickName;

            //responseText == text 형식
            string jsonStr = getRequest(url);
            User userInfo = JsonSerializer.Deserialize<User>(jsonStr);

            _logger.LogWarning(userInfo.nickname);
            return userInfo.accessId;
        }

        public List<string> getMatches(string accessId)
        {
            string url = baseURL + "users/" + accessId + "/matches?matchtype=50&offset=0&limit=10";

            string jsonStr = getRequest(url);
            List<string> matches = JsonSerializer.Deserialize<List<string>>(jsonStr);

            _logger.LogWarning(matches[0]);
            return matches;
        }

        public MatchDTO getMatchInfo(string match)
        {
            string url = baseURL + "matches/" + match;

            string jsonStr = getRequest(url);

            _logger.LogWarning(jsonStr);
            MatchDTO matchDTO = JsonSerializer.Deserialize<MatchDTO>(jsonStr);

            _logger.LogWarning(matchDTO.matchId);
            return matchDTO;
        }

        public int getTotalScore(List<string> matches, string accessId)
        {

            /*퇴장수, 경고수, 태클수, 오프사이드수,
             * 퇴장수 : matchinfo -> matchDetail -> redCards
             * 경고수 : matchinfo -> matchDetail -> yellowCards
             * 오프사이드 수 : matchinfo -> matchDetail -> offsideCount
             * 슈팅 총 수 : matchinfo -> shoot -> shootTotal
             * 실패 블락킹 : matchinfo -> defence -> blockTry - blockSuccess
             * 실패 태클링 : matchinfo -> defence -> tackleTry - tackleSuccess
             * (퇴장수*100 + 경고수*80 + 오프사이드 수*20 + 슈팅 총 수 *5 + 실패 블락킹*30 + 실패 태클링*30) => 100+80+20+5+30+30 = 265  
             */
            int totalScore = 0;

            foreach (string match in matches)
            {
                MatchDTO matchDTO = getMatchInfo(match);
                int idx = 0;
                if(matchDTO.matchInfo[1].accessId.Equals(accessId))
                {
                    idx = 1;
                }

                MatchInfoDTO matchInfo = matchDTO.matchInfo[idx];
                int redCards = matchInfo.matchDetail.redCards;
                int yellowCards = matchInfo.matchDetail.yellowCards;
                int offsideCount = matchInfo.matchDetail.OffsideCount;
                int shoots = matchInfo.shoot.shootTotal;
                int blockings = matchInfo.defence.blockTry - matchInfo.defence.blockSuccess;
                int tacklings = matchInfo.defence.tackleTry - matchInfo.defence.tackleSuccess;

                totalScore += ((redCards * 100) + (yellowCards * 80) + (offsideCount * 20) + (shoots * 5) + (blockings * 30) + (tacklings * 30));
            }

            int finalScore = totalScore / 1000;

            _logger.LogWarning(totalScore.ToString());
            _logger.LogWarning(finalScore.ToString());
            return finalScore;
        }

        public string getRequest(string url)
        {
            string responseText = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 30 * 1000; // 30초
            request.Headers.Add("Authorization", apiKey); // 헤더 추가 방법

            using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
            {
                HttpStatusCode status = resp.StatusCode;
                Console.WriteLine(status);  // 정상이면 "OK"

                Stream respStream = resp.GetResponseStream();

                using (StreamReader sr = new StreamReader(respStream))
                {
                    responseText = sr.ReadToEnd();
                }
            }
            return responseText;
        }



    }
}
