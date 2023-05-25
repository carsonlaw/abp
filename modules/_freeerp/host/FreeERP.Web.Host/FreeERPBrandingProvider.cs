using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FreeERP;

[Dependency(ReplaceServices = true)]
public class FreeERPBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FreeERP";
}
