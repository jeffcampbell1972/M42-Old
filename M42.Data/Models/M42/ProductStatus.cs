using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("ProductStatuses", Schema = "Store")]
    public class ProductStatus
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }

        private static List<ProductStatus> values;
        public static List<ProductStatus> Values
        {
            get
            {
                if (values != null)
                {
                    return values;
                }
                else
                {
                    values = new List<ProductStatus>() {
                        ForSale ,
                        OnHold ,
                        Sold
                    };
                }
                return values;
            }
        }

        static private ProductStatus forsale;
        static private ProductStatus onhold;
        static private ProductStatus sold;

        static public ProductStatus ForSale { get { return forsale ?? (forsale = new ProductStatus { Id = 1, Name = "For Sale" }); } }
        static public ProductStatus OnHold { get { return onhold ?? (onhold = new ProductStatus { Id = 2, Name = "On Hold" }); } }
        static public ProductStatus Sold { get { return sold ?? (sold = new ProductStatus { Id = 3, Name = "Sold" }); } }
    }
}
