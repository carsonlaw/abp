using Volo.Match.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Volo.Match
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(MatchEntityFrameworkCoreTestModule)
        )]
    public class MatchDomainTestModule : AbpModule
    {
        
    }
}
