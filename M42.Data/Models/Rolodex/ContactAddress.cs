using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("ContactAddresses", Schema = "Rolodex")]
    public class ContactAddress
    {
        public int Id { get; set; }

        public int ContactId { get; set; }
        public int AddressId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Address Address { get; set; }
    }
}