using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Volo.HDShop.EntityFrameworkCore
{
    public class HDShopModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public HDShopModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}