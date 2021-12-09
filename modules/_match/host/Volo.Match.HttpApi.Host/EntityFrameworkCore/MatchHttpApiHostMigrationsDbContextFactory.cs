using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Volo.Match.EntityFrameworkCore
{
    public class MatchHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<MatchHttpApiHostMigrationsDbContext>
    {
        public MatchHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<MatchHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Match"));

            return new MatchHttpApiHostMigrationsDbContext(builder.Options);
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
