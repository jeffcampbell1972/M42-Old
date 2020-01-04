using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Identifier { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string Nickname { get; set; }
        public string PreferredName { get; set; }

        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}",
                PreferredName ?? FirstName,
                LastName);
        }
    }
}