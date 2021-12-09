using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Volo.HDShop
{
    [DependsOn(
        typeof(HDShopHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class HDShopConsoleApiClientModule : AbpModule
    {
        
    }
}
