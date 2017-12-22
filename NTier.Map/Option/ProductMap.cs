using NTier.Core.Map;
using NTier.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Map.Option
{
    public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");
            Property(x=>x.Name).HasMaxLength(50).IsOptional();
            Property(x => x.Price).IsOptional();
            Property(x => x.Quantity).IsOptional();
            Property(x => x.UnitsInStock).IsOptional();
            Property(x => x.ImagePath).IsOptional();

            HasRequired(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(true);//Kategorisi silinirse ürün silinir.
        }

    }
}
