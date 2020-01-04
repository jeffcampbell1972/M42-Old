using System;
using System.Collections.Generic;
using System.Text;

namespace M42.Sports
{
    public class Series
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public Season Season { get; set; }
        public List<Game> Games { get; set; }
    }
}
