using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Phones", Schema = "Rolodex")]
    public class Phone
    {
        public int Id { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneTypeId { get; set; }

        public virtual PhoneType PhoneType { get; set; }
    }
}