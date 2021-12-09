using Volo.HDShop.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.HDShop
{
    public abstract class HDShopController : AbpController
    {
        protected HDShopController()
        {
            LocalizationResource = typeof(HDShopResource);
        }
    }
}
