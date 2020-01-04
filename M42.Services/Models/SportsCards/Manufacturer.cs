using System;
using System.Collections.Generic;
using System.Text;

namespace M42.SportsCards
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
