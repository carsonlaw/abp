using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Volo.HDShop.MongoDB
{
    public class HDShopMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public HDShopMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}