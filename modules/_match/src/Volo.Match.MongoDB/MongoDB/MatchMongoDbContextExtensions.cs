using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Volo.Match.MongoDB
{
    public static class MatchMongoDbContextExtensions
    {
        public static void ConfigureMatch(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new MatchMongoModelBuilderConfigurationOptions(
                MatchDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}