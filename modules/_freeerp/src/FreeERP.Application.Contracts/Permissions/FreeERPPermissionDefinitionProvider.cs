using FreeERP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FreeERP.Permissions
{
    public class FreeERPPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(FreeERPPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(FreeERPPermissions.MyPermission1, L("Permission:MyPermission1"));
            var categoryManagement = myGroup.AddPermission(FreeERPPermissions.Categories.Default, L("Permission:CategoryManagement"));
            //.RequireGlobalFeatures(typeof(BlogsFeature));
            categoryManagement.AddChild(FreeERPPermissions.Categories.Create, L("Permission:CategoryManagement.Create"));
            categoryManagement.AddChild(FreeERPPermissions.Categories.Update, L("Permission:CategoryManagement.Update"));
            categoryManagement.AddChild(FreeERPPermissions.Categories.Delete, L("Permission:CategoryManagement.Delete"));
            var productManagement = myGroup.AddPermission(FreeERPPermissions.Products.Default, L("Permission:ProductManagement"));
            //.RequireGlobalFeatures(typeof(BlogsFeature));
            productManagement.AddChild(FreeERPPermissions.Products.Create, L("Permission:ProductManagement.Create"));
            productManagement.AddChild(FreeERPPermissions.Products.Update, L("Permission:ProductManagement.Update"));
            productManagement.AddChild(FreeERPPermissions.Products.Delete, L("Permission:ProductManagement.Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<FreeERPResource>(name);
        }
    }
}
