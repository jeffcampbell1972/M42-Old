using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Instruments", Schema = "Music")]
    public class Instrument
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}