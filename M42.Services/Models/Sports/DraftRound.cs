using System;
using System.Collections.Generic;
using System.Text;

namespace M42.Sports
{
    public class DraftRound
    {
        public string Identifier { get; set; }
        public string Label { get; set; }
        public Draft Draft { get; set; }
        public int Number { get; set; }
        public List<DraftPick> Picks { get; set; }
    }
}
