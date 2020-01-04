using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Countries", Schema = "Rolodex")]
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string ISOCode { get; set; }

        private static List<Country> values;
        public static List<Country> Values
        {
            get
            {
                if (values != null)
                {
                    return values;
                }
                else
                {
                    values = new List<Country>() {
                        US ,
                        Canada
                    };
                }
                return values;
            }
        }

        static private Country us;
        static private Country canada;

        static public Country US { get { return us ?? (us = new Country { Id = 1, Name = "United States", Abbreviation = "US", ISOCode = "USA" }); } }
        static public Country Canada { get { return canada ?? (canada = new Country { Id = 2, Name = "Canada", Abbreviation = "CN", ISOCode = "CAN" }); } }
    }
}