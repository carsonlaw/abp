using System.Threading.Tasks;
using FreeERP.Localization;
using FreeERP.MultiTenancy;
using FreeERP.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace FreeERP.Web.Menus
{
    public class FreeERPMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            await Task.Run(() =>
            {
                var administration = context.Menu.GetAdministration();
                var l = context.GetLocalizer<FreeERPResource>();
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

                context.Menu.Items.Insert(
                    1,
                    new ApplicationMenuItem(
                        FreeERPMenus.Products,
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
                var products = context.Menu.GetMenuItem(FreeERPMenus.Products);
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
                                        FreeERPMenus.Product,
                                        l["Menu:Product"],
                                        "~/Products/Product",
                                        icon: "fas fa-archive",
                                        order: 1
                                    )
                                    .RequirePermissions(FreeERPPermissions.Products.Default)
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
    }
}
