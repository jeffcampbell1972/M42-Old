using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Inventories", Schema = "SportsCards")]
    public class Inventory
    {
        public int Id { get; set; }
        public int? SerialNumber { get; set; }
        public string GradingService { get; set; }
	    public string GradingServiceReferenceNo { get; set; }
        public int CardId { get; set; }
        public int ContainerId { get; set; }
        public bool InStock { get; set; }
        public Card Card { get; set; }
        public Container Container { get; set; }
    }
}