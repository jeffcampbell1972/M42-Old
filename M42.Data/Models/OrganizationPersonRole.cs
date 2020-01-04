using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    public class OrganizationPersonRole
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual Person Person { get; set; }
        public virtual Role Role { get; set; }
    }
}