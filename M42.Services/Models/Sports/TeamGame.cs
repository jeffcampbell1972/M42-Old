using System;
using System.Collections.Generic;
using System.Text;

namespace M42.Sports
{
    public class TeamGame
    {
        public virtual Game Game { get; set; }
        public virtual Team Opponent { get; set; }
        public string HomeAwayIndicator { get; set; }
        public string WinLossIndicator { get; set; }
        public string Score { get; set; }
    }
}
