using Volo.Match.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Volo.Match.Permissions
{
    public class MatchPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MatchPermissions.GroupName, L("Permission:Match"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MatchResource>(name);
        }
    }
}