using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Volo.HDShop
{
    [DependsOn(
        typeof(HDShopApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class HDShopHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "HDShop";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(HDShopApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
