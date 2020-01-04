using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Containers", Schema = "SportsCards")]
    public class Container
    {
        public int Id { get; set; }

        public string Identifier { get; set; }
        public string Name { get; set; }

        public int ContainerTypeId { get; set; }
        public int LocationId { get; set; }
        public ContainerType ContainerType { get; set; }
        public Location Location { get; set; }

    }
}