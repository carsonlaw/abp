using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Volo.HDShop
{
    [DependsOn(
        typeof(HDShopDomainModule),
        typeof(HDShopApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class HDShopApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<HDShopApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<HDShopApplicationModule>(validate: true);
            });
        }
    }
}
