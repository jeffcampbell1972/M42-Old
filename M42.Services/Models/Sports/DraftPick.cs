using System;
using System.Collections.Generic;
using System.Text;

namespace M42.Sports
{
    public class DraftPick
    {
        public int Id { get; set; }
        public string Identifier { get; set; }

        public Person Person { get; set; }
        public Team Team { get; set; }
        public Draft Draft { get; set; }
        public int Round { get; set; }
        public int Pick { get; set; }
        public string RoundWithSuffix { get; set; }
        public string Description { get; set; }
    }
}
