using FreeERP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FreeERP.Permissions
{
    public class FreeERPPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var productsGroup = context.AddGroup(FreeERPPermissions.ProductsGroupName, L("Permission:ProductsGroupName"));
            var purchaseGroup = context.AddGroup(FreeERPPermissions.PurchaseGroupName, L("Permission:PurchaseGroupName"));
            //Define your own permissions here. Example:
            //myGroup.AddPermission(FreeERPPermissions.MyPermission1, L("Permission:MyPermission1"));
            var categoryManagement = productsGroup.AddPermission(FreeERPPermissions.Categories.Default, L("Permission:CategoryManagement"));
            //.RequireGlobalFeatures(typeof(BlogsFeature));
            categoryManagement.AddChild(FreeERPPermissions.Categories.Create, L("Permission:CategoryManagement.Create"));
            categoryManagement.AddChild(FreeERPPermissions.Categories.Update, L("Permission:CategoryManagement.Update"));
            categoryManagement.AddChild(FreeERPPermissions.Categories.Delete, L("Permission:CategoryManagement.Delete"));
            var productManagement = productsGroup.AddPermission(FreeERPPermissions.Products.Default, L("Permission:ProductManagement"));
            productManagement.AddChild(FreeERPPermissions.Products.Create, L("Permission:ProductManagement.Create"));
            productManagement.AddChild(FreeERPPermissions.Products.Update, L("Permission:ProductManagement.Update"));
            productManagement.AddChild(FreeERPPermissions.Products.Delete, L("Permission:ProductManagement.Delete"));
            var purchaseOrderManagement = purchaseGroup.AddPermission(FreeERPPermissions.PurchaseOrder.Default, L("Permission:PurchaseOrderManagement"));
            purchaseOrderManagement.AddChild(FreeERPPermissions.PurchaseOrder.Create, L("Permission:PurchaseOrderManagement.Create"));
            purchaseOrderManagement.AddChild(FreeERPPermissions.PurchaseOrder.Update, L("Permission:PurchaseOrderManagement.Update"));
            purchaseOrderManagement.AddChild(FreeERPPermissions.PurchaseOrder.Delete, L("Permission:PurchaseOrderManagement.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<FreeERPResource>(name);
        }
    }
}
