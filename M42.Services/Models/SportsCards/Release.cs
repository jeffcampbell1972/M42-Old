using System;
using System.Collections.Generic;
using System.Text;
using M42.Sports;

namespace M42.SportsCards
{
    public class Release
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Sport Sport { get; set; }
        public League League { get; set; }
        public ReleaseYear ReleaseYear { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Brand Brand { get; set; }

        public List<Set> Sets { get; set; }
    }
}
