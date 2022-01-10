using System.Threading.Tasks;
using Volo.Abp.SettingManagement;

namespace FreeERP.Settings
{
    public class HelpSettingAppService
        : IHelpSettingAppService
    {
        protected readonly ISettingManager _manager;
        public async Task<HelpSettingDto> GetHelpSettingDto()
        {
            var isShow = await _manager.GetOrNullForCurrentUserAsync(FreeERPSettings.HelpSettingIsShow);
            return new HelpSettingDto()
            {
                IsShow = bool.Parse(isShow)
            };
        }

        public async Task SetHelpSettingDto(HelpSettingDto dto)
        {
            await _manager.SetForCurrentUserAsync(FreeERPSettings.HelpSettingIsShow, dto.IsShow.ToString());
        }
    }
}