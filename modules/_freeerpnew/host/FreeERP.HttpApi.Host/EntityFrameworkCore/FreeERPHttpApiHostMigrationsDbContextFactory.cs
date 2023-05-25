using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FreeERP.EntityFrameworkCore;

public class FreeERPHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<FreeERPHttpApiHostMigrationsDbContext>
{
    public FreeERPHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<FreeERPHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("FreeERP"));

        return new FreeERPHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
