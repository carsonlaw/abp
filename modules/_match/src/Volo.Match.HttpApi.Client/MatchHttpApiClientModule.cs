using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Volo.Match
{
    [DependsOn(
        typeof(MatchApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class MatchHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Match";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(MatchApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
