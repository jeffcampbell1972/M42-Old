using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Addresses", Schema = "Rolodex")]
    public class Address
    {
        public int Id { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public int? ProvinceId { get; set; }
        public string PostalCode { get; set; }
        public int CountryId { get; set; }

        public virtual State State { get; set; }
        public virtual Country Country { get; set; }
    }
}