using Volo.Abp.Modularity;

namespace FreeERP
{
    [DependsOn(
        typeof(FreeERPApplicationModule),
        typeof(FreeERPDomainTestModule)
        )]
    public class FreeERPApplicationTestModule : AbpModule
    {

    }
}