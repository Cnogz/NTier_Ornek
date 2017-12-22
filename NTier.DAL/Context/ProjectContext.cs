using NTier.Core.Entity;
using NTier.Map.Option;
using NTier.Model.Option;
using NTier.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NTier.DAL.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()/*:base("YMS5122_NTier")*/
        {
            Database.Connection.ConnectionString = "Server=.;Database=NTier;uid=sa;pwd=123;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//Tekilleştirme,çoğullaştırma işlemini kaldırır.

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public override int SaveChanges()
        {
            //Yeni eklenen veya yeni güncellenen tüm entityleri kayıt edilmeden önce yakalıyoruz ve düzenliyoruz.
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            int User = 1;
            string GetIp = RemoteIp.GetIpAddress();

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;

                if (item!=null)
                {
                    if (item.State==EntityState.Added)
                    {
                        entity.CreatedUserName = identity;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedDate = dateTime;
                        entity.CreatedBy = User;
                        entity.CreatedIp = GetIp;
                    }
                    else if (item.State==EntityState.Modified)
                    {
                        entity.ModifiedUserName = identity;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedDate = dateTime;
                        entity.ModifiedBy = User;
                        entity.ModifiedIp = GetIp;
                    }
                }
            }

            return base.SaveChanges();
        }


    }
}