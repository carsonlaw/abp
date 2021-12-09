using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.HDShop.Goods;
using Volo.HDShop.Orders;
using Volo.HDShop.Users;

namespace Volo.HDShop.EntityFrameworkCore
{
    [ConnectionStringName(HDShopDbProperties.ConnectionStringName)]
    public class HDShopDbContext : AbpDbContext<HDShopDbContext>, IHDShopDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<ShopUser> ShopUsers { get; set; }
        public DbSet<GoodCategory> GoodCategories { get; set; }
        public DbSet<GoodProperty> GoodProperties { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeliverCompany> DeliverCompanys { get; set; }
        public DbSet<DeliverAddress> DeliverAddress { get; set; }
        public DbSet<PayCompany> PayCompanys { get; set; }


        public HDShopDbContext(DbContextOptions<HDShopDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureHDShop();
        }
    }
}