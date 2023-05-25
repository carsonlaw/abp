using Localization.Resources.AbpUi;
using FreeERP.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FreeERP;

[DependsOn(
    typeof(FreeERPApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class FreeERPHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(FreeERPHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<FreeERPResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
