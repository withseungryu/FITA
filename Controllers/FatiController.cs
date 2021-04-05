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
            

            List<string> nickNames = new List<string>();
            nickNames.Add(accessId);
            return View(nickNames);
        }

        //유저 닉네임을 사용해 유저 아이디 반환
        public string getAccessID(string nickName)
        {
            string url = baseURL + "users?nickname=" + nickName;
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


            //responseText == text 형식
            string jsonStr = responseText;
            User userInfo = JsonSerializer.Deserialize<User>(jsonStr);

            _logger.LogWarning(userInfo.nickname);
            return userInfo.accessId;
        }
    }
}
