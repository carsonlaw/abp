using Volo.HDShop.Localization;
using Volo.Abp.Application.Services;

namespace Volo.HDShop
{
    public abstract class HDShopAppService : ApplicationService
    {
        protected HDShopAppService()
        {
            LocalizationResource = typeof(HDShopResource);
            ObjectMapperContext = typeof(HDShopApplicationModule);
        }
    }
}
