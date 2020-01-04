using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("ContactPhones", Schema = "Rolodex")]
    public class ContactPhone
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int PhoneId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Phone Phone { get; set; }
    }
}