using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Volo.Match
{
    [DependsOn(
        typeof(MatchDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class MatchApplicationContractsModule : AbpModule
    {

    }
}
