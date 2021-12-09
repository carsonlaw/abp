using Volo.HDShop.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Volo.HDShop
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(HDShopEntityFrameworkCoreTestModule)
        )]
    public class HDShopDomainTestModule : AbpModule
    {
        
    }
}
