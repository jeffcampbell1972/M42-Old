using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Brands", Schema = "SportsCards")]
    public class Brand
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
    }
}