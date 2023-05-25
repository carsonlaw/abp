using FreeERP.Localization;
using Volo.Abp.Application.Services;

namespace FreeERP;

public abstract class FreeERPAppService : ApplicationService
{
    protected FreeERPAppService()
    {
        LocalizationResource = typeof(FreeERPResource);
        ObjectMapperContext = typeof(FreeERPApplicationModule);
    }
}
