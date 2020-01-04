using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("PhoneTypes", Schema = "Rolodex")]
    public class PhoneType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private static List<PhoneType> values;
        public static List<PhoneType> Values
        {
            get
            {
                if (values != null)
                {
                    return values;
                }
                else
                {
                    values = new List<PhoneType>() {
                        Home ,
                        Work ,
                        Mobile
                    };
                }
                return values;
            }
        }

        static private PhoneType home;
        static private PhoneType work;
        static private PhoneType mobile;

        static public PhoneType Home { get { return home ?? (home = new PhoneType { Id = 1, Name = "Home" }); } }
        static public PhoneType Work { get { return work ?? (work = new PhoneType { Id = 2, Name = "Work" }); } }
        static public PhoneType Mobile { get { return mobile ?? (mobile = new PhoneType { Id = 3, Name = "Mobile" }); } }
    }
}
