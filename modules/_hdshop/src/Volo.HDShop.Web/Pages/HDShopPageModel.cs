using Volo.HDShop.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Volo.HDShop.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class HDShopPageModel : AbpPageModel
    {
        protected HDShopPageModel()
        {
            LocalizationResourceType = typeof(HDShopResource);
            ObjectMapperContext = typeof(HDShopWebModule);
        }
    }
}