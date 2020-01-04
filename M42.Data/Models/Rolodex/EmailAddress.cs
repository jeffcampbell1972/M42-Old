using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("EmailAddresses", Schema = "Rolodex")]
    public class EmailAddress
    {
        public int Id { get; set; }
        public string LocalPart { get; set; }
        public string Domain { get; set; }
    }
}