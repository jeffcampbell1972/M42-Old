using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Franchises", Schema = "Sports")]
    public class Franchise
    {
        [Key]
        [ForeignKey("Organization")]
        public int Id { get; set; }
        public int SportId { get; set; }
        public bool IsProfessional { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual Sport Sport { get; set; }
    }
}