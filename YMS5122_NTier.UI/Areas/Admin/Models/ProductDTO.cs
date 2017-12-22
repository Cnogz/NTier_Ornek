using NTier.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YMS5122_NTier.UI.Areas.Admin.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public short? UnitsInStock { get; set; }
        public string Quantity { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }

    }
}