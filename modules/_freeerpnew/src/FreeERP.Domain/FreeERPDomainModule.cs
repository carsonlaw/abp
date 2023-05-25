using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FreeERP;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(FreeERPDomainSharedModule)
)]
public class FreeERPDomainModule : AbpModule
{

}
