using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FreeERP.EntityFrameworkCore;

[ConnectionStringName(FreeERPDbProperties.ConnectionStringName)]
public class FreeERPDbContext : AbpDbContext<FreeERPDbContext>, IFreeERPDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public FreeERPDbContext(DbContextOptions<FreeERPDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureFreeERP();
    }
}
