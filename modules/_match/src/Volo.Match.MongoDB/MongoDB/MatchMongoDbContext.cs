using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Volo.Match.MongoDB
{
    [ConnectionStringName(MatchDbProperties.ConnectionStringName)]
    public class MatchMongoDbContext : AbpMongoDbContext, IMatchMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureMatch();
        }
    }
}