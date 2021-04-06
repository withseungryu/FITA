using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FATIApp.Models.Fati
{
    public class PlayerDTO
    {
        public int spId { get; set; }
        public int spPosition { get; set; }
        public int spGrade { get; set; }
        public string status { get; set; } //필요없음
    }
}
