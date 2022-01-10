using System.Threading.Tasks;

namespace FreeERP.Settings
{
    public interface IHelpSettingAppService
    {
        Task<HelpSettingDto> GetHelpSettingDto();
        Task SetHelpSettingDto(HelpSettingDto dto);
    }
}