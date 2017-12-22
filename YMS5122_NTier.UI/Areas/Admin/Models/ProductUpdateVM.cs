using NTier.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YMS5122_NTier.UI.Areas.Admin.Models
{
    public class ProductUpdateVM
    {
        public ProductUpdateVM()
        {
            Categories = new List<Category>();
            Product = new ProductDTO();
        }

        public List<Category> Categories { get; set; }
        public ProductDTO Product { get; set; }

    }
}