using System;
using System.Collections.Generic;
using System.Text;

namespace M42.Sports
{
    public class Game
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Team WinningTeam { get; set; }
        public Team LosingTeam { get; set; }
        public Team Winner { get; set; }
        public string Score { get; set; }
        public int? WinningScore { get; set; }
        public int? LosingScore { get; set; }
        public int? NumOvertimes { get; set; }
        public List<Person> MVPs { get; set; }
    }
}
