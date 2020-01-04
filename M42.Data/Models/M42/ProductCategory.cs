using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("ProductCategories", Schema = "Store")]
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private static List<ProductCategory> values;
        public static List<ProductCategory> Values
        {
            get
            {
                if (values != null)
                {
                    return values;
                }
                else
                {
                    values = new List<ProductCategory>() {
                        NativeJewelry ,
                        SportsCards ,
                        DepressionGlass
                    };
                }
                return values;
            }
        }

        static private ProductCategory nativeJewelry;
        static private ProductCategory sportsCards;
        static private ProductCategory depressionGlass;

        static public ProductCategory NativeJewelry { get { return nativeJewelry ?? (nativeJewelry = new ProductCategory { Id = 1, Name = "Native Jewelry" }); } }
        static public ProductCategory SportsCards { get { return sportsCards ?? (sportsCards = new ProductCategory { Id = 2, Name = "Sports Cards" }); } }
        static public ProductCategory DepressionGlass { get { return depressionGlass ?? (depressionGlass = new ProductCategory { Id = 3, Name = "Depression Glass" }); } }
    }
}