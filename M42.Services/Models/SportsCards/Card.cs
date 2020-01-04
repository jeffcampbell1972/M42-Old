using System;
using System.Collections.Generic;
using System.Text;
using M42.Sports;

namespace M42.SportsCards
{
    public class Card
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public bool IsRookieCard { get; set; }
        public bool IsAutographed { get; set; }
        public bool IsRelic { get; set; }
        public Set Set { get; set; }
        public int CardNumber { get; set; }
        public List<string> Attributes { get; set; }
        public List<Person> People { get; set; }
        public List<Team> Teams { get; set; }
        public List<Game> Games { get; set; }
    }
}
