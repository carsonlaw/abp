using FreeERP.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FreeERP
{
    [DependsOn(
        typeof(FreeERPEntityFrameworkCoreTestModule)
        )]
    public class FreeERPDomainTestModule : AbpModule
    {

    }
}