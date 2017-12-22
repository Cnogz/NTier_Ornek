using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Option
{
    public class Product:CoreEntity
    {
        public decimal? Price { get; set; }
        public short? UnitsInStock { get; set; }
        public string Quantity { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

    }
}
