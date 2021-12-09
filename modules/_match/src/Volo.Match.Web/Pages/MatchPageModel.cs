using Volo.Match.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Volo.Match.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class MatchPageModel : AbpPageModel
    {
        protected MatchPageModel()
        {
            LocalizationResourceType = typeof(MatchResource);
            ObjectMapperContext = typeof(MatchWebModule);
        }
    }
}