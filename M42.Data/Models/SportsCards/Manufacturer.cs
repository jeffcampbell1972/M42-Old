using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Manufacturers", Schema = "SportsCards")]
    public class Manufacturer
    {
        [Key]
        [ForeignKey("Organization")]
        public int Id { get; set; }

        public virtual Organization Organization { get; set; }
    }
}