using FreeERP.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FreeERP.Blazor.Server.Host;

public abstract class FreeERPComponentBase : AbpComponentBase
{
    protected FreeERPComponentBase()
    {
        LocalizationResource = typeof(FreeERPResource);
    }
}
