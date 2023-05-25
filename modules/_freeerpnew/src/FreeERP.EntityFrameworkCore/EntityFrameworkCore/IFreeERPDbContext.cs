using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FreeERP.EntityFrameworkCore;

[ConnectionStringName(FreeERPDbProperties.ConnectionStringName)]
public interface IFreeERPDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
