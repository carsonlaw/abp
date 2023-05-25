using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace FreeERP.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(FreeERPBlazorModule)
    )]
public class FreeERPBlazorServerModule : AbpModule
{

}
