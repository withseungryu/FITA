using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FATIApp.Models.Fati
{
    public class DefenceDTO
    {
        public int blockTry { get; set; }
        public int blockSuccess { get; set; }
        public int tackleTry { get; set; }
        public int tackleSuccess { get; set; }
    }
}
