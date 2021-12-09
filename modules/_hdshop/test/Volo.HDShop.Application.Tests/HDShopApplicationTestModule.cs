using Volo.Abp.Modularity;

namespace Volo.HDShop
{
    [DependsOn(
        typeof(HDShopApplicationModule),
        typeof(HDShopDomainTestModule)
        )]
    public class HDShopApplicationTestModule : AbpModule
    {

    }
}
