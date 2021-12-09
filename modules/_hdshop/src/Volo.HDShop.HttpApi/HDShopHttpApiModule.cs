using Localization.Resources.AbpUi;
using Volo.HDShop.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Volo.HDShop
{
    [DependsOn(
        typeof(HDShopApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class HDShopHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(HDShopHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<HDShopResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
