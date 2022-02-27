using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using FreeERP.Products;
using FreeERP.Purchases;
using FreeERP.MediaDescriptors;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using FreeERP.Stories;
using FreeERP.Suppliers;
using FreeERP.Customers;

namespace FreeERP.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class FreeERPDbContext :
        AbpDbContext<FreeERPDbContext>,
        IIdentityDbContext,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSKU> ProductSKUs { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Store> Stories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<PurchaseOrderLine> PurchaseOrderLines {get;set;}
        public DbSet<MediaDescriptor> MediaDescriptors { get; set; }

        #region Entities from the modules

        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */

        //Identity
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }

        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion

        public FreeERPDbContext(DbContextOptions<FreeERPDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            #region  /* Configure your own tables/entities inside here */

            builder.Entity<Category>(b =>
            {
                b.ToTable(FreeERPConsts.DbTablePrefix + "Categories", FreeERPConsts.DbSchema);
                //b.ConfigureByConvention();
                b.Property(p => p.Name).IsRequired().HasMaxLength(CategoryConsts.MaxNameLength);
                b.Property(p => p.Slug).IsRequired().HasMaxLength(CategoryConsts.MaxSlugLength);

                b.HasIndex(p => p.Slug);
                //b.ApplyObjectExtensionMappings();
            });

            builder.Entity<Product>(b =>
            {
                b.ToTable(FreeERPConsts.DbTablePrefix + "Products", FreeERPConsts.DbSchema);
                b.Property(p => p.Name).IsRequired().HasMaxLength(ProductConsts.MaxNameLength);
                b.Property(p => p.Code).IsRequired().HasMaxLength(ProductConsts.MaxCodeLength);
                b.Property(p => p.MediaId);
                b.Property(p => p.Description).HasMaxLength(ProductConsts.MaxDescriptionLength);
                //b.HasMany(p => p.SKUs);
                b.HasMany(p => p.Stocks);

                b.HasIndex(p => new { p.CategoryId, p.Code });
            });

            builder.Entity<ProductSKU>(b =>
            {
                b.ToTable(FreeERPConsts.DbTablePrefix + "ProductSKUs", FreeERPConsts.DbSchema);
                b.Property(p => p.Name).IsRequired().HasMaxLength(ProductSKUConsts.MaxNameLength);
                b.Property(p => p.PropertyIds).HasConversion(new ValueConverter<IList<Guid>, string>(
                    v => JsonConvert.SerializeObject(v), // Convert to string for persistence
                    v => JsonConvert.DeserializeObject<IList<Guid>>(v)))
                    .Metadata.SetValueComparer(
                        new ValueComparer<IList<Guid>>(
                            (c1, c2) => c1.SequenceEqual(c2),
                            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                            c => (IList<Guid>)c.ToHashSet()
                        )
                    );
                b.HasMany(p => p.Stocks);
            });
            builder.Entity<ProductUnit>(b =>
            {
                b.ToTable(FreeERPConsts.DbTablePrefix + "ProductUnits", FreeERPConsts.DbSchema);
                b.Property(p => p.Name).IsRequired().HasMaxLength(ProductUnitConsts.MaxNameLength);
                b.HasOne(p => p.SmallerUnit)
                    .WithMany(p => p.BiggerUnits);
            });
            builder.Entity<ProductProperty>(b =>
            {
                b.ToTable(FreeERPConsts.DbTablePrefix + "ProductProperties", FreeERPConsts.DbSchema);
                b.Property(p => p.Name).IsRequired().HasMaxLength(ProductPropertyConsts.MaxNameLength);
                b.HasOne(p => p.Parent)
                    .WithMany(p => p.Items);
            });

            builder.Entity<ProductStock>(b =>
            {
                b.ToTable(FreeERPConsts.DbTablePrefix + "ProductStocks", FreeERPConsts.DbSchema);
                //b.HasKey(f => new { f.ProductOrSkuId, f.StoreId });
            });

            builder.Entity<PurchaseOrder>(b =>
            {
                b.ToTable(FreeERPConsts.DbTablePrefix + "PurchaseOrders", FreeERPConsts.DbSchema);
                b.Property(p => p.OrderNo).IsRequired().HasMaxLength(PurchaseOrderConsts.MaxOrderNoLength);
                b.Property(p => p.Description).HasMaxLength(PurchaseOrderConsts.MaxDescriptionLength);
                b.HasMany(p => p.Lines);
            });

            builder.Entity<PurchaseOrderLine>(b =>
            {
                b.ToTable(FreeERPConsts.DbTablePrefix + "PurchaseOrderLines", FreeERPConsts.DbSchema);
                //b.HasKey(f => new { f.OrderId, f.ProductId, f.ProductSkuId, f.StoreId });
            });

            builder.Entity<MediaDescriptor>(b =>
            {
                b.ToTable(FreeERPConsts.DbTablePrefix + "MediaDescriptors", FreeERPConsts.DbSchema);
                b.Property(p => p.Name).HasMaxLength(MediaDescriptorConsts.MaxNameLength);
                b.Property(p => p.MimeType).HasMaxLength(MediaDescriptorConsts.MaxMimeTypeLength);
                b.Property(p => p.EntityType).HasMaxLength(MediaDescriptorConsts.MaxEntityTypeLength);
            });


            builder.Entity<Store>(b =>
            {
                b.ToTable(FreeERPConsts.DbTablePrefix + "Stories", FreeERPConsts.DbSchema);
                b.Property(p => p.Name).IsRequired().HasMaxLength(StoreConsts.MaxNameLength);
                b.Property(p => p.Description).HasMaxLength(StoreConsts.MaxDescriptionLength);
            });


            builder.Entity<Supplier>(b =>
            {
                b.ToTable(FreeERPConsts.DbTablePrefix + "Suppliers", FreeERPConsts.DbSchema);
                b.Property(p => p.Name).IsRequired().HasMaxLength(StoreConsts.MaxNameLength);
                b.Property(p => p.Description).HasMaxLength(StoreConsts.MaxDescriptionLength);
            });


            builder.Entity<Customer>(b =>
            {
                b.ToTable(FreeERPConsts.DbTablePrefix + "Customers", FreeERPConsts.DbSchema);
                b.Property(p => p.Name).IsRequired().HasMaxLength(StoreConsts.MaxNameLength);
                b.Property(p => p.Description).HasMaxLength(StoreConsts.MaxDescriptionLength);
            });

            #endregion

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(FreeERPConsts.DbTablePrefix + "YourEntities", FreeERPConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}
