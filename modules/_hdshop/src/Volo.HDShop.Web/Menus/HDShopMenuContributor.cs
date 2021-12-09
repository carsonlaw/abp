using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Volo.HDShop.Web.Menus
{
    public class HDShopMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(HDShopMenus.Prefix, displayName: "HDShop", "~/HDShop", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}