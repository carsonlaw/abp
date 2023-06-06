using FreeERP.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FreeERP.Blazor.components;

public abstract class FreeERPComponentBase : AbpComponentBase
{
    protected FreeERPComponentBase()
    {
        LocalizationResource = typeof(FreeERPResource);
    }
}
