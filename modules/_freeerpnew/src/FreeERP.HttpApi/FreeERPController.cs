using FreeERP.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FreeERP;

public abstract class FreeERPController : AbpControllerBase
{
    protected FreeERPController()
    {
        LocalizationResource = typeof(FreeERPResource);
    }
}
