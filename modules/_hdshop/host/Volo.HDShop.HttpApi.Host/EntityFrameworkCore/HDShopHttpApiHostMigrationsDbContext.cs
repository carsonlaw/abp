using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.HDShop.EntityFrameworkCore
{
    public class HDShopHttpApiHostMigrationsDbContext : AbpDbContext<HDShopHttpApiHostMigrationsDbContext>
    {
        public HDShopHttpApiHostMigrationsDbContext(DbContextOptions<HDShopHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureHDShop();
        }
    }
}
