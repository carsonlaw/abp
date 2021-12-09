using Microsoft.Extensions.DependencyInjection;
using Volo.HDShop.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Volo.HDShop.Blazor
{
    [DependsOn(
        typeof(HDShopHttpApiClientModule),
        typeof(AbpAutoMapperModule)
        )]
    public class HDShopBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<HDShopBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<HDShopBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new HDShopMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(HDShopBlazorModule).Assembly);
            });
        }
    }
}