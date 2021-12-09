using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Volo.Match.MongoDB
{
    [ConnectionStringName(MatchDbProperties.ConnectionStringName)]
    public interface IMatchMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
