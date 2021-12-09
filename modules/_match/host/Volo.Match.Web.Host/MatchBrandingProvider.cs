using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Volo.Match
{
    [Dependency(ReplaceServices = true)]
    public class MatchBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Match";
    }
}
