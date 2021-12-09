using System.Threading.Tasks;
using Volo.HDShop.Localization;
using Volo.Abp.UI.Navigation;

namespace Volo.HDShop.Blazor.Host
{
    public class HDShopHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<HDShopResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "HDShop.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}
