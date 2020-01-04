using System;
using System.Collections.Generic;
using System.Text;

namespace M42.Sports
{
    public class Draft
    {
        public int Id { get; set; }
        public string Identifier { get; set; }

        public string Name { get; set; }
        public Season Season { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int NumberOfRounds { get; set; }

        public List<DraftPick> Picks { get; set; }
        public List<DraftRound> Rounds { get; set; }
    }
}
