using System;
using System.Collections.Generic;
using System.Text;

namespace M42.Sports
{
    public class Championship
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Score { get; set; }
        public Team WinningTeam { get; set; }
        public Team LosingTeam { get; set; }
        public List<Game> Games { get; set; }
    }
}
