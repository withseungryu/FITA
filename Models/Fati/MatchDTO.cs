using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FATIApp.Models.Fati
{
    public class MatchDTO
    {
        public string matchId { get; set; }
        public string matchDate { get; set; }
        public int matchType { get; set; }
        public List<MatchInfoDTO> matchInfo { get; set; }
    }
}
