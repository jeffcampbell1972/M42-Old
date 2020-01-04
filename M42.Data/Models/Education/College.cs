using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Colleges", Schema = "Education")]
    public class College
    {
        [Key]
        [ForeignKey("Organization")]
        public int Id { get; set; }
        public string Nickname { get; set; }

        public virtual Organization Organization { get; set; }
    }
}