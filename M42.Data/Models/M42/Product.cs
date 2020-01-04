using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Products", Schema = "Store")]
    public class Product
    {
        public int Id { get; set; }
        public string Identifier { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int InventoryStatusId { get; set; }
        public int InventoryTypeId { get; set; }
        public decimal? ListPrice { get; set; }
        public decimal? MinimumPrice { get; set; }
        public decimal? SalePrice { get; set; }
        
        public virtual ProductStatus ProductStatus { get; set; }
        public virtual ProductType InventoryType { get; set; }
    }
}