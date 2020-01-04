using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("HOFers", Schema = "Sports")]
    public class HOFer
    {
        public int Id { get; set; }
        public int HOFId { get; set; }
        public int PersonId { get; set; }
        public int YearInducted { get; set; }

        public virtual HOF HOF { get; set; }
        public virtual Person Person { get; set; }

    }
}