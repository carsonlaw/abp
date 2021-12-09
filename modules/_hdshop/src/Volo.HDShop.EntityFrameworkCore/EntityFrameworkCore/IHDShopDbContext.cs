using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.HDShop.Goods;
using Volo.HDShop.Orders;
using Volo.HDShop.Users;

namespace Volo.HDShop.EntityFrameworkCore
{
    [ConnectionStringName(HDShopDbProperties.ConnectionStringName)]
    public interface IHDShopDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<ShopUser> ShopUsers { get; set; }
        DbSet<GoodCategory> GoodCategories { get; set; }
        DbSet<GoodProperty> GoodProperties { get; set; }
        DbSet<Good> Goods { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<DeliverCompany> DeliverCompanys { get; set; }
        DbSet<DeliverAddress> DeliverAddress { get; set; }
        DbSet<PayCompany> PayCompanys { get; set; }
    }
}