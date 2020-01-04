using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("ContactEmailAddresses", Schema = "Rolodex")]
    public class ContactEmailAddress
    {
        public int Id { get; set; }

        public int ContactId { get; set; }
        public int EmailAddressId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual EmailAddress EmailAddress { get; set; }
    }
}