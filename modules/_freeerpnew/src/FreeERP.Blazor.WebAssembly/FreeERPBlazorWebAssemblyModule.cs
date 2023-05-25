using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FreeERP.Blazor.WebAssembly;

[DependsOn(
    typeof(FreeERPBlazorModule),
    typeof(FreeERPHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class FreeERPBlazorWebAssemblyModule : AbpModule
{

}
