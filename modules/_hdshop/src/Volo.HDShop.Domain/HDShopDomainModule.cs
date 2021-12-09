using Volo.Abp.Domain;
using Volo.Abp.Users;
using Volo.Abp.BlobStoring;
using Volo.Abp.Modularity;

namespace Volo.HDShop
{
    [DependsOn(
        typeof(HDShopDomainSharedModule),
        typeof(AbpUsersDomainModule),
        typeof(AbpDddDomainModule),
        typeof(AbpBlobStoringModule)
    )]
    public class HDShopDomainModule : AbpModule
    {

    }
}
