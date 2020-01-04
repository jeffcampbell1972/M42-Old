using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Drafts", Schema = "Sports")]
    public class Draft
    {
        [Key]
        [ForeignKey("Season")]
        public int Id { get; set; }

        public virtual Season Season { get; set; }
    }
}