using System;
using System.Collections.Generic;
using System.Text;

namespace M42.SportsCards
{
    public class Set
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public int? NumCards { get; set; }
        public Release Release { get; set; }
        public bool IsBaseSet { get; set; }
        public List<Card> Cards { get; set; }
    }
}
