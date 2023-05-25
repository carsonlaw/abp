using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FreeERP.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class FreeERPBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FreeERP";
}
