using System.Threading.Tasks;
using FreeERP.Localization;
using FreeERP.MultiTenancy;
using FreeERP.Permissions;
using Microsoft.Extensions.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace FreeERP.Web.Menus
{
    public class FreeERPMenuContributor : IMenuContributor
    {
        IStringLocalizer l;
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            l = context.GetLocalizer<FreeERPResource>();
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
                await ConfigureProductMenuAsync(context);
                await ConfigureStoriesMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            await Task.Run(() =>
            {
                var administration = context.Menu.GetAdministration();
                context.Menu.Items.Insert(
                    0,
                    new ApplicationMenuItem(
                        FreeERPMenus.Home,
                        l["Menu:Home"],
                        "~/",
                        icon: "fas fa-home",
                        order: 0
                    )
                );


                if (MultiTenancyConsts.IsEnabled)
                {
                    administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
                }
                else
                {
                    administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
                }

                administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
                administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
            });
        }

        private async Task ConfigureProductMenuAsync(MenuConfigurationContext context)
        {
            await Task.Run(() =>
            {
                context.Menu.Items.Insert(
                    1,
                    new ApplicationMenuItem(
                        FreeERPMenus.ProductsGroup,
                        l["Menu:ProductsGroupName"],
                        "~/",
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
                        l["Menu:Category"],
                        "~/Products/Category",
                        icon: "fas fa-align-justify",
                        order: 0
                    )
                    .RequirePermissions(FreeERPPermissions.Categories.Default)
                );
                products.AddItem(
                    new ApplicationMenuItem(
                        FreeERPMenus.ProductUnit,
                        l["Menu:ProductUnit"],
                        "~/products/ProductUnit",
                        icon: "fas fa-cube",
                        order: 1
                    )
                    .RequirePermissions(FreeERPPermissions.ProductUnits.Default)
                );
                products.AddItem(
                    new ApplicationMenuItem(
                        FreeERPMenus.Product,
                        l["Menu:Product"],
                        "~/Products/Product",
                        icon: "fas fa-archive",
                        order: 2
                    )
                    .RequirePermissions(FreeERPPermissions.Products.Default)
                );
            });

        }

        private async Task ConfigureStoriesMenuAsync(MenuConfigurationContext context)
        {
            await Task.Run(() =>
            {
                context.Menu.Items.Insert(
                    2,
                    new ApplicationMenuItem(
                        FreeERPMenus.StoriesGroup,
                        l["Menu:StoriesGroupName"],
                        "~/",
                        icon: "fas fa-briefcase",
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
                        l["Menu:Store"],
                        "~/Stories/Store",
                        icon: "fas fa-align-justify",
                        order: 0
                    )
                    .RequirePermissions(FreeERPPermissions.Stories.Default)
                );
            });

        }
    }
}
