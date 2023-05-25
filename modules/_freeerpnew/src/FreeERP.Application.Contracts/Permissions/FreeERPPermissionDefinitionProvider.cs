using FreeERP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FreeERP.Permissions;

public class FreeERPPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FreeERPPermissions.GroupName, L("Permission:FreeERP"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FreeERPResource>(name);
    }
}
