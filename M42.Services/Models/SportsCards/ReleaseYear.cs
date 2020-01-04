using System;
using System.Collections.Generic;
using System.Text;
using M42.Sports;

namespace M42.SportsCards
{
    public class ReleaseYear
    {
        public string Identifier { get; set; }
        public int Year { get; set; }
        public Sport Sport { get; set; }
        public int NumManufacturers { get; set; }
        public int NumReleases { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Release> Releases { get; set; }
    }
}
