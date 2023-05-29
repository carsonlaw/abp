using System.Threading.Tasks;
using FreeERP.MultiTenancy;
using Volo.Abp.UI.Navigation;
using Volo.Abp.SettingManagement;
using Microsoft.Extensions.Localization;
using FreeERP.Localization;
using FreeERP.Permissions;
using Volo.Abp.Authorization.Permissions;

namespace FreeERP.Blazor.Menus;

public class FreeERPMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        IStringLocalizer L = context.GetLocalizer<FreeERPResource>();
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context, L);
            await ConfigureProductMenuAsync(context, L);
            await ConfigureStoriesMenuAsync(context, L);
            await ConfigurePurchasesMenuAsync(context, L);
            await ConfigureSalesMenuAsync(context, L);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context, IStringLocalizer L)
    {
        await Task.Run(() =>
        {
            var administration = context.Menu.GetAdministration();
            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    FreeERPMenus.Home,
                    L["Menu:Home"],
                    "~/FreeErp",
                    icon: "fas fa-home",
                    order: 0
                )
            );



        });
    }

    private async Task ConfigureProductMenuAsync(MenuConfigurationContext context, IStringLocalizer L)
    {
        await Task.Run(() =>
        {
            context.Menu.Items.Insert(
                1,
                new ApplicationMenuItem(
                    FreeERPMenus.ProductsGroup,
                    L["Menu:ProductsGroupName"],
                    "~/FreeErp",
                    icon: "fas fa-briefcase",
                    order: 1
                )
                .RequirePermissions(false, new string[]{
                        FreeERPPermissions.Products.Default,
                        FreeERPPermissions.Categories.Default
                })
            );
            var products = context.Menu.GetMenuItem(FreeERPMenus.ProductsGroup);
            products.AddItem(
                new ApplicationMenuItem(
                    FreeERPMenus.Category,
                    L["Menu:Category"],
                    "~/FreeErp/Products/Category",
                    icon: "fas fa-align-justify",
                    order: 0
                )
                .RequirePermissions(FreeERPPermissions.Categories.Default)
            );
            products.AddItem(
                new ApplicationMenuItem(
                    FreeERPMenus.ProductUnit,
                    L["Menu:ProductUnit"],
                    "~/FreeErp/products/ProductUnit",
                    icon: "fas fa-cube",
                    order: 1
                )
                .RequirePermissions(FreeERPPermissions.ProductUnits.Default)
            );
            products.AddItem(
                new ApplicationMenuItem(
                    FreeERPMenus.Product,
                    L["Menu:Product"],
                    "~/FreeErp/Products/Product",
                    icon: "fas fa-archive",
                    order: 2
                )
                .RequirePermissions(FreeERPPermissions.Products.Default)
            );
        });

    }

    private async Task ConfigureStoriesMenuAsync(MenuConfigurationContext context, IStringLocalizer L)
    {
        await Task.Run(() =>
        {
            context.Menu.Items.Insert(
                2,
                new ApplicationMenuItem(
                    FreeERPMenus.StoriesGroup,
                    L["Menu:StoriesGroupName"],
                    "~/FreeErp/",
                    icon: "fas fa-laptop-house",
                    order: 2
                )
                .RequirePermissions(false, new string[]{
                        FreeERPPermissions.Stories.Default
                })
            );
            var stories = context.Menu.GetMenuItem(FreeERPMenus.StoriesGroup);
            stories.AddItem(
                new ApplicationMenuItem(
                    FreeERPMenus.Store,
                    L["Menu:Store"],
                    "~/FreeErp/Stories/Store",
                    icon: "fas fa-store",
                    order: 0
                )
                .RequirePermissions(FreeERPPermissions.Stories.Default)
            );
        });

    }

    private async Task ConfigurePurchasesMenuAsync(MenuConfigurationContext context, IStringLocalizer L)
    {
        await Task.Run(() =>
        {
            context.Menu.Items.Insert(
                3,
                new ApplicationMenuItem(
                    FreeERPMenus.PurchasesGroup,
                    L["Menu:PurchasesGroupName"],
                    "~/FreeErp/",
                    icon: "fas fa-cart-arrow-down",
                    order: 3
                )
                .RequirePermissions(false, new string[]{
                        FreeERPPermissions.Suppliers.Default,
                        FreeERPPermissions.PurchaseOrders.Default
                })
            );
            var purchases = context.Menu.GetMenuItem(FreeERPMenus.PurchasesGroup);
            purchases.AddItem(
                new ApplicationMenuItem(
                    FreeERPMenus.Supplier,
                    L["Menu:Supplier"],
                    "~/FreeErp/Suppliers/Supplier",
                    icon: "fas fa-user-tie",
                    order: 0
                )
                .RequirePermissions(FreeERPPermissions.Suppliers.Default)
            );
            purchases.AddItem(
                new ApplicationMenuItem(
                    FreeERPMenus.PurchaseOrder,
                    L["Menu:PurchaseOrder"],
                    "~/FreeErp/Purchases/PurchaseOrder",
                    icon: "fas fa-file-invoice",
                    order: 1
                )
                .RequirePermissions(FreeERPPermissions.PurchaseOrders.Default)
            );
        });

    }

    private async Task ConfigureSalesMenuAsync(MenuConfigurationContext context, IStringLocalizer L)
    {
        await Task.Run(() =>
        {
            context.Menu.Items.Insert(
                4,
                new ApplicationMenuItem(
                    FreeERPMenus.SalesGroup,
                    L["Menu:SalesGroupName"],
                    "~/FreeErp/",
                    icon: "fas fa-gifts",
                    order: 4
                )
                .RequirePermissions(false, new string[]{
                        FreeERPPermissions.Customers.Default,
                        FreeERPPermissions.SaleOrders.Default
                })
            );
            var sales = context.Menu.GetMenuItem(FreeERPMenus.SalesGroup);
            sales.AddItem(
                new ApplicationMenuItem(
                    FreeERPMenus.Customer,
                    L["Menu:Customer"],
                    "~/FreeErp/Customers/Customer",
                    icon: "fas fa-user-tag",
                    order: 0
                )
                .RequirePermissions(FreeERPPermissions.Customers.Default)
            );
            sales.AddItem(
                new ApplicationMenuItem(
                    FreeERPMenus.SaleOrder,
                    L["Menu:SaleOrder"],
                    "~/FreeErp/Sales/SaleOrder",
                    icon: "fas fa-file-invoice-dollar",
                    order: 1
                )
                .RequirePermissions(FreeERPPermissions.SaleOrders.Default)
            );
        });

    }
}
