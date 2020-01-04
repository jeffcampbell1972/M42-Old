using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Sets", Schema = "SportsCards")]
    public class Set
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public int ReleaseId { get; set; }
        public string Name { get; set; }
        public bool IsBase { get; set; }
        public int NumCards { get; set; }

        public virtual Release Release { get; set; }

        public override string ToString()
        {
            return this.Release.ToString() + " - " + Name;
        }
    }
}