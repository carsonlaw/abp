using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FreeERP.MongoDB;

[ConnectionStringName(FreeERPDbProperties.ConnectionStringName)]
public class FreeERPMongoDbContext : AbpMongoDbContext, IFreeERPMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureFreeERP();
    }
}
