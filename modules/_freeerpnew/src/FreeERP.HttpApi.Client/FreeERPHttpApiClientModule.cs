using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FreeERP;

[DependsOn(
    typeof(FreeERPApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class FreeERPHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(FreeERPApplicationContractsModule).Assembly,
            FreeERPRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<FreeERPHttpApiClientModule>();
        });

    }
}
