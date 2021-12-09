using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Match.Matchs;

namespace Volo.Match.EntityFrameworkCore
{
    [DependsOn(
        typeof(MatchDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class MatchEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MatchDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Matchs.Match,EFCoreMatchRepository>();
            });
        }
    }
}