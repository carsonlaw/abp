using FreeERP.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FreeERP.Pages;

public abstract class FreeERPPageModel : AbpPageModel
{
    protected FreeERPPageModel()
    {
        LocalizationResourceType = typeof(FreeERPResource);
    }
}
