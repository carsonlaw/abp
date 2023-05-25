using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FreeERP.Blazor.Menus;

public class FreeERPMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(FreeERPMenus.Prefix, displayName: "FreeERP", "/FreeERP", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
