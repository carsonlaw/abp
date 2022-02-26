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
            var purchasesGroup = context.AddGroup(FreeERPPermissions.PurchasesGroupName, L("Permission:PurchasesGroupName"));
            var SalesGroup = context.AddGroup(FreeERPPermissions.SalesGroupName, L("Permission:SalesGroupName"));
            var storiesGroup = context.AddGroup(FreeERPPermissions.StoriesGroupName, L("Permission:StoriesGroupName"));

            //Define your own permissions here. Example:
            //myGroup.AddPermission(FreeERPPermissions.MyPermission1, L("Permission:MyPermission1"));
            var categoryManagement = productsGroup.AddPermission(FreeERPPermissions.Categories.Default, L("Permission:CategoryManagement"));
            //.RequireGlobalFeatures(typeof(BlogsFeature));
            categoryManagement.AddChild(FreeERPPermissions.Categories.Create, L("Permission:Create"));
            categoryManagement.AddChild(FreeERPPermissions.Categories.Update, L("Permission:Update"));
            categoryManagement.AddChild(FreeERPPermissions.Categories.Delete, L("Permission:Delete"));
            var productManagement = productsGroup.AddPermission(FreeERPPermissions.Products.Default, L("Permission:ProductManagement"));
            productManagement.AddChild(FreeERPPermissions.Products.Create, L("Permission:Create"));
            productManagement.AddChild(FreeERPPermissions.Products.Update, L("Permission:Update"));
            productManagement.AddChild(FreeERPPermissions.Products.Delete, L("Permission:Delete"));

            var productUnitManagement = productsGroup.AddPermission(FreeERPPermissions.ProductUnits.Default, L("Permission:ProductUnitManagement"));
            productUnitManagement.AddChild(FreeERPPermissions.ProductUnits.Create, L("Permission:Create"));
            productUnitManagement.AddChild(FreeERPPermissions.ProductUnits.Update, L("Permission:Update"));
            productUnitManagement.AddChild(FreeERPPermissions.ProductUnits.Delete, L("Permission:Delete"));


            var purchaseOrderManagement = purchasesGroup.AddPermission(FreeERPPermissions.PurchaseOrders.Default, L("Permission:PurchaseOrderManagement"));
            purchaseOrderManagement.AddChild(FreeERPPermissions.PurchaseOrders.Create, L("Permission:Create"));
            purchaseOrderManagement.AddChild(FreeERPPermissions.PurchaseOrders.Update, L("Permission:Update"));
            purchaseOrderManagement.AddChild(FreeERPPermissions.PurchaseOrders.Delete, L("Permission:Delete"));

            var suppliersManagement = purchasesGroup.AddPermission(FreeERPPermissions.Suppliers.Default, L("Permission:SupplierManagement"));
            suppliersManagement.AddChild(FreeERPPermissions.Suppliers.Create, L("Permission:Create"));
            suppliersManagement.AddChild(FreeERPPermissions.Suppliers.Update, L("Permission:Update"));
            suppliersManagement.AddChild(FreeERPPermissions.Suppliers.Delete, L("Permission:Delete"));

            var storeManagement = storiesGroup.AddPermission(FreeERPPermissions.Stories.Default, L("Permission:StoreManagement"));
            storeManagement.AddChild(FreeERPPermissions.Stories.Create, L("Permission:Create"));
            storeManagement.AddChild(FreeERPPermissions.Stories.Update, L("Permission:Update"));
            storeManagement.AddChild(FreeERPPermissions.Stories.Delete, L("Permission:Delete"));

            var SettingManagement = context.GetGroupOrNull("SettingManagement");
            SettingManagement.AddPermission(FreeERPPermissions.SettingManagement.HelpSetting, L("Permission:HelpSetting"));

            var customerManagement = SalesGroup.AddPermission(FreeERPPermissions.Customers.Default, L("Permission:CustomerManagement"));
            customerManagement.AddChild(FreeERPPermissions.Customers.Create, L("Permission:Create"));
            customerManagement.AddChild(FreeERPPermissions.Customers.Update, L("Permission:Update"));
            customerManagement.AddChild(FreeERPPermissions.Customers.Delete, L("Permission:Delete"));

            var saleOrderManagement = SalesGroup.AddPermission(FreeERPPermissions.SaleOrders.Default, L("Permission:SaleOrderManagement"));
            saleOrderManagement.AddChild(FreeERPPermissions.SaleOrders.Create, L("Permission:Create"));
            saleOrderManagement.AddChild(FreeERPPermissions.SaleOrders.Update, L("Permission:Update"));
            saleOrderManagement.AddChild(FreeERPPermissions.SaleOrders.Delete, L("Permission:Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<FreeERPResource>(name);
        }
    }
}
