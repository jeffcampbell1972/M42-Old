using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    public class Organization
    {
        public int Id { get; set; }

        public string Identifier { get; set; }

        public string Name { get; set; }
        public bool ActiveFlag { get; set; }
        public int? YearEstablished { get; set; }
        public int? YearEnded { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}