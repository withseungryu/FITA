using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FATIApp.Models.Fati
{
    public class PassDTO
    {
        public int passTry { get; set; }
        public int passSuccess { get; set; }
        public int shortPassTry { get; set; }
        public int shortPassSuccess { get; set; }
        public int longPassTry { get; set; }
        public int longPassSuccess { get; set; }
        public int bouncingLobPassTry { get; set; }
        public int bouncingLobPassSuccess { get; set; }
        public int drivenGroundPassTry { get; set; }
        public int drivenGroundPassSuccess { get; set; }
        public int throughPassTry { get; set; }
        public int throughPassSuccess { get; set; }
        public int lobbedThroughPassTry { get; set; }
        public int lobbedThroughPassSuccess { get; set; }
    }
}
