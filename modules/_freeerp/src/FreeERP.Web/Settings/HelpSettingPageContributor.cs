using System.Threading.Tasks;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using FreeERP.Web.Components;
using Microsoft.Extensions.Localization;
using FreeERP.Localization;
using Microsoft.AspNetCore.Authorization;
using FreeERP.Permissions;
using Microsoft.Extensions.DependencyInjection;

namespace FreeERP.Web
{
    public class HelpSettingPageContributor : ISettingPageContributor
    {
        public async Task ConfigureAsync(SettingPageCreationContext context)
        {
            if (!await CheckPermissionsAsync(context))
                return;
            var L = context.ServiceProvider.GetRequiredService<IStringLocalizer<FreeERPResource>>();
            context.Groups.Add(
                new SettingPageGroup(
                    "FreeERP.HelpSettingGroup",
                    L["HelpSettingGroup"],
                    typeof(HelpSettingGroupViewComponent)
                )
            );

        }

        public Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
        {
            // You can check the permissions here
            var auth = context.ServiceProvider.GetRequiredService<IAuthorizationService>();
            var ret = auth.IsGrantedAsync(FreeERPPermissions.SettingManagement.HelpSetting).Result;
            return Task.FromResult(ret);
        }

    }
}