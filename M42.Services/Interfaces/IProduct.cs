using System;
using System.Collections.Generic;
using System.Text;

namespace M42.Services
{
    public interface IProduct
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? ListPrice { get; set; }
        public decimal? MinimumPrice { get; set; }
        public decimal? SalePrice { get; set; }
    }
}
