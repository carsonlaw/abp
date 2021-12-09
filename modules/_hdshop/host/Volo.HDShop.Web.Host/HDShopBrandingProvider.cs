using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Volo.HDShop
{
    [Dependency(ReplaceServices = true)]
    public class HDShopBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "HDShop";
    }
}
