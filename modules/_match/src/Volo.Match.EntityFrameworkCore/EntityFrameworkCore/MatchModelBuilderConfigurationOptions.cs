using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Volo.Match.EntityFrameworkCore
{
    public class MatchModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public MatchModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}