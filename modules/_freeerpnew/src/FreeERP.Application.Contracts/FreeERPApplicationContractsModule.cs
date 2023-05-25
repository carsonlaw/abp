using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FreeERP;

[DependsOn(
    typeof(FreeERPDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class FreeERPApplicationContractsModule : AbpModule
{

}
