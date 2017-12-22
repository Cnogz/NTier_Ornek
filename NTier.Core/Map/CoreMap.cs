using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Core.Map
{
    // T generic bir anlama sahiptir(Genel). CoreEntity sınıfından miras alacak herhangi bir sınıfı temsil eder.(AppUser,Category,Product vb...)
    public class CoreMap<T>:EntityTypeConfiguration<T> where T:CoreEntity
    {
        public CoreMap()
        {
            //Fluent API
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.CreatedUserName).HasColumnName("CreatedUserName").HasMaxLength(50).IsOptional();
            Property(x => x.CreatedComputerName).HasColumnName("CreatedComputerName").HasMaxLength(50).IsOptional();
            Property(x => x.CreatedIp).HasColumnName("CreatedIp").HasMaxLength(50).IsOptional();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();
            Property(x => x.CreatedBy).IsOptional();

            Property(x => x.MasterId).HasColumnName("MasterId").IsOptional();

            Property(x => x.ModifiedUserName).HasColumnName("ModifiedUserName").HasMaxLength(50).IsOptional();
            Property(x => x.ModifiedComputerName).HasColumnName("ModifiedComputerName").HasMaxLength(50).IsOptional();
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsOptional();
            Property(x => x.ModifiedBy).IsOptional();
            Property(x => x.ModifiedIp).HasColumnName("ModifiedIp").HasMaxLength(50).IsOptional();

            Property(x => x.Status).HasColumnName("Status").IsOptional();
        }
    }
}
