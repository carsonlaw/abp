using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Volo.Match
{
    [DependsOn(
        typeof(MatchHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class MatchConsoleApiClientModule : AbpModule
    {
        
    }
}
