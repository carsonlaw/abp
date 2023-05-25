using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FreeERP.MongoDB;

public static class FreeERPMongoDbContextExtensions
{
    public static void ConfigureFreeERP(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
