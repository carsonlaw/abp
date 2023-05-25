using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FreeERP.MongoDB;

[ConnectionStringName(FreeERPDbProperties.ConnectionStringName)]
public interface IFreeERPMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
