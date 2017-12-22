using NTier.Core.Entity;
using System.Collections.Generic;


namespace NTier.Model.Option
{
    public class Category:CoreEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}
