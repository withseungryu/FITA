using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FATIApp.Models.Fati
{
    public class ShootDTO
    {
        public int shootTotal { get; set; }
        public int effectiveShootTotal { get; set; }
        public int shootOutSource { get; set; }
        public int goalTotal { get; set; }
        public int goalTotalDisplay { get; set; }
        public int ownGoal { get; set; }
        public int shootHeading { get; set; }
        public int goalHeading { get; set; }
        public int shootFreekick { get; set; }
        public int goalFreekick { get; set; }
        public int shootInPenalty { get; set; }
        public int goalInPenalty { get; set; }
        public int shootOutPenalty { get; set; }
        public int goalOutPenalty { get; set; }
        public int shootPenaltyKick { get; set; }
        public int goalPenaltyKick { get; set; }
    }
}
