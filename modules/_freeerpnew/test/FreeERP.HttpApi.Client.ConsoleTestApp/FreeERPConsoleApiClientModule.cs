using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FreeERP;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FreeERPHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class FreeERPConsoleApiClientModule : AbpModule
{

}
