using Volo.Match.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Volo.Match.Pages
{
    public abstract class MatchPageModel : AbpPageModel
    {
        protected MatchPageModel()
        {
            LocalizationResourceType = typeof(MatchResource);
        }
    }
}