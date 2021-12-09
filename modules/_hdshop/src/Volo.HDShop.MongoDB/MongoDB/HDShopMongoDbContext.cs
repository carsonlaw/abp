using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Volo.HDShop.MongoDB
{
    [ConnectionStringName(HDShopDbProperties.ConnectionStringName)]
    public class HDShopMongoDbContext : AbpMongoDbContext, IHDShopMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureHDShop();
        }
    }
}