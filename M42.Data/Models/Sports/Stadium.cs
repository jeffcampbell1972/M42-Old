using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Stadia", Schema = "Sports")]
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int? YearBuilt { get; set; }
        public int? YearDestroyed { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}