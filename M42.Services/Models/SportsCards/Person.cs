using System;
using System.Collections.Generic;
using System.Text;
using M42.SportsCards;

namespace M42.SportsCards
{
    public class Person
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string College { get; set; }
        public int NumCards { get; set; }
        public List<Card> Cards { get; set; }
    }
}
