using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Volo.Match.MongoDB
{
    public class MatchMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public MatchMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}