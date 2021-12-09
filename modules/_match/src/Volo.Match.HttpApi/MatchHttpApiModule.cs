using Localization.Resources.AbpUi;
using Volo.Match.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Volo.Match
{
    [DependsOn(
        typeof(MatchApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class MatchHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MatchHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<MatchResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
