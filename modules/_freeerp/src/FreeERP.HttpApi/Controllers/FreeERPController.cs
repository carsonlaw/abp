using FreeERP.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FreeERP.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class FreeERPController : AbpController
    {
        protected FreeERPController()
        {
            LocalizationResource = typeof(FreeERPResource);
        }
    }
}