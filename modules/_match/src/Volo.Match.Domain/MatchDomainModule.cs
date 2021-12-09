using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Volo.Match
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(MatchDomainSharedModule)
    )]
    public class MatchDomainModule : AbpModule
    {

    }
}
