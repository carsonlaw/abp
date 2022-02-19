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
            var storiesGroup = context.AddGroup(FreeERPPermissions.StoriesGroupName, L("Permission:StoriesGroupName"));

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

            var productUnitManagement = productsGroup.AddPermission(FreeERPPermissions.ProductUnits.Default, L("Permission:ProductUnitManagement"));
            productUnitManagement.AddChild(FreeERPPermissions.ProductUnits.Create, L("Permission:ProductManagement.Create"));
            productUnitManagement.AddChild(FreeERPPermissions.ProductUnits.Update, L("Permission:ProductManagement.Update"));
            productUnitManagement.AddChild(FreeERPPermissions.ProductUnits.Delete, L("Permission:ProductManagement.Delete"));


            var purchaseOrderManagement = purchaseGroup.AddPermission(FreeERPPermissions.PurchaseOrder.Default, L("Permission:PurchaseOrderManagement"));
            purchaseOrderManagement.AddChild(FreeERPPermissions.PurchaseOrder.Create, L("Permission:PurchaseOrderManagement.Create"));
            purchaseOrderManagement.AddChild(FreeERPPermissions.PurchaseOrder.Update, L("Permission:PurchaseOrderManagement.Update"));
            purchaseOrderManagement.AddChild(FreeERPPermissions.PurchaseOrder.Delete, L("Permission:PurchaseOrderManagement.Delete"));

            var storeManagement = storiesGroup.AddPermission(FreeERPPermissions.Stories.Default, L("Permission:StoreManagement"));
            storeManagement.AddChild(FreeERPPermissions.Stories.Create, L("Permission:StoreManagement.Create"));
            storeManagement.AddChild(FreeERPPermissions.Stories.Update, L("Permission:StoreManagement.Update"));
            storeManagement.AddChild(FreeERPPermissions.Stories.Delete, L("Permission:StoreManagement.Delete"));

            var SettingManagement = context.GetGroupOrNull("SettingManagement");
            SettingManagement.AddPermission(FreeERPPermissions.SettingManagement.HelpSetting, L("Permission:HelpSetting"));


        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<FreeERPResource>(name);
        }
    }
}
