using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FATIApp.Models.Fati
{
    public class MatchInfoDTO
    {
        public string accessId { get; set; }
        public string nickname { get; set; }
        public MatchDetailDTO matchDetail { get; set; }
        public ShootDTO shoot { get; set; }
        public List<object> shootDetail { get; set; } //정보 필요없음.
        public PassDTO pass { get; set; }
        public DefenceDTO defence { get; set; }
        public List<object> player { get; set; } //정보 필요없음
    }
}
