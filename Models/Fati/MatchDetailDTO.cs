using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FATIApp.Models.Fati
{
    public class MatchDetailDTO
    {
        public int seasonId { get; set; }
        public string matchResult { get; set; }
        public int matchEndType { get; set; }
        public int systemPause { get; set; }
        public int foul { get; set; }
        public int injury { get; set; }
        public int redCards { get; set; }
        public int yellowCards { get; set; }
        public int dribble { get; set; }
        public int cornerKick { get; set; }
        public int possession { get; set; }
        public int OffsideCount { get; set; }
        public double averageRating { get; set; }
        public string controller { get; set; }
    }
}
