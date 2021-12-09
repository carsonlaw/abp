using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Volo.HDShop
{
    [DependsOn(
        typeof(HDShopDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class HDShopApplicationContractsModule : AbpModule
    {

    }
}
