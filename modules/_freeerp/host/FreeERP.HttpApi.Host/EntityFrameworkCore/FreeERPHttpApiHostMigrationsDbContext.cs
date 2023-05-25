using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FreeERP.EntityFrameworkCore;

public class FreeERPHttpApiHostMigrationsDbContext : AbpDbContext<FreeERPHttpApiHostMigrationsDbContext>
{
    public FreeERPHttpApiHostMigrationsDbContext(DbContextOptions<FreeERPHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureFreeERP();
    }
}
