using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Musicians", Schema = "Music")]
    public class Musician
    {
        [Key]
        [ForeignKey("Person")]
        public int Id { get; set; }

        public virtual Person Person { get; set; }
    }
}