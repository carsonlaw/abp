using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Volo.HDShop.EntityFrameworkCore
{
    public class HDShopHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<HDShopHttpApiHostMigrationsDbContext>
    {
        public HDShopHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<HDShopHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("HDShop"));

            return new HDShopHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
