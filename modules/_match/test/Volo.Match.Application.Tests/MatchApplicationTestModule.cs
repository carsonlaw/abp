using Volo.Abp.Modularity;

namespace Volo.Match
{
    [DependsOn(
        typeof(MatchApplicationModule),
        typeof(MatchDomainTestModule)
        )]
    public class MatchApplicationTestModule : AbpModule
    {

    }
}
