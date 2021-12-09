using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.Users.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.HDShop.Goods;
using Volo.HDShop.Orders;
using Volo.HDShop.Users;

namespace Volo.HDShop.EntityFrameworkCore
{
    public static class HDShopDbContextModelCreatingExtensions
    {
        public static void ConfigureHDShop(
            this ModelBuilder builder,
            Action<HDShopModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new HDShopModelBuilderConfigurationOptions(
                HDShopDbProperties.DbTablePrefix,
                HDShopDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            var stringArrayComparer = new ValueComparer<string[]>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToHashSet().ToArray());

            builder.Entity<ShopUser>(b => {
                b.ToTable(options.TablePrefix + "ShopUser", options.Schema);
                b.ConfigureByConvention();
                b.ConfigureAbpUser();
            });

            #region Good
            builder.Entity<GoodCategory>(b =>
            {
                b.ToTable(options.TablePrefix + "GoodCategory", options.Schema);
                b.ConfigureFullAuditedAggregateRoot();

            });
            builder.Entity<GoodProperty>(b =>
            {
                b.ToTable(options.TablePrefix + "GoodProperty", options.Schema);
                b.ConfigureByConvention();
            });
            builder.Entity<Good>(b =>
            {
                b.ToTable(options.TablePrefix + "Good", options.Schema);
                b.ConfigureByConvention();
                b.HasMany(f => f.GoodCategorys).WithMany(f=>f.Goods);
                b.HasMany(f => f.GoodProperties).WithMany(f => f.Goods);
                b.OwnsOne(f => f.SaleStates);
                b.Property(f => f.ImageUrls).HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
                .Metadata.SetValueComparer(stringArrayComparer);
            });
            builder.Entity<GoodSku>(b =>
            {
                b.ToTable(options.TablePrefix + "GoodSku", options.Schema);
                b.ConfigureFullAudited();
            });

            #endregion

            #region Order
            builder.Entity<Order>(b =>
            {
                b.ToTable(options.TablePrefix + "Order", options.Schema);
                b.ConfigureByConvention();
                b.OwnsOne(f => f.PayOrder)
                    .Property(f=>f.PayPrice).HasColumnType("decimal(18,2)");
                b.OwnsOne(f => f.DeliverOrder);
            });
            builder.Entity<OrderLine>(b =>
            {
                b.ToTable(options.TablePrefix + "OrderLine", options.Schema);
                b.HasKey(f => new { f.OrderId, f.GoodSkuId });
                b.Property(f => f.Price).HasColumnType("decimal(18,2)");

            });
            builder.Entity<DeliverCompany>(b =>
            {
                b.ToTable(options.TablePrefix + "DeliverCompany", options.Schema);
                b.ConfigureByConvention();

            });
            builder.Entity<DeliverAddress>(b =>
            {
                b.ToTable(options.TablePrefix + "DeliverAddress", options.Schema);
                b.ConfigureByConvention();

            });
            builder.Entity<PayCompany>(b =>
            {
                b.ToTable(options.TablePrefix + "PayCompany", options.Schema);
                b.ConfigureByConvention();

            });
            #endregion
        }
    }
}