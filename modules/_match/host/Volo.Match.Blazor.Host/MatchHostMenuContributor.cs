using System.Threading.Tasks;
using Volo.Match.Localization;
using Volo.Abp.UI.Navigation;

namespace Volo.Match.Blazor.Host
{
    public class MatchHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<MatchResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "Match.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}
