using Volo.HDShop.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Volo.HDShop.Pages
{
    public abstract class HDShopPageModel : AbpPageModel
    {
        protected HDShopPageModel()
        {
            LocalizationResourceType = typeof(HDShopResource);
        }
    }
}