using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Volo.HDShop.MongoDB
{
    [ConnectionStringName(HDShopDbProperties.ConnectionStringName)]
    public interface IHDShopMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
