using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Volo.HDShop.MongoDB
{
    public static class HDShopMongoDbContextExtensions
    {
        public static void ConfigureHDShop(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new HDShopMongoModelBuilderConfigurationOptions(
                HDShopDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}