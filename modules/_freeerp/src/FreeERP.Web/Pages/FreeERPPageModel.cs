using FreeERP.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FreeERP.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class FreeERPPageModel : AbpPageModel
    {
        protected FreeERPPageModel()
        {
            LocalizationResourceType = typeof(FreeERPResource);
        }
    }
}