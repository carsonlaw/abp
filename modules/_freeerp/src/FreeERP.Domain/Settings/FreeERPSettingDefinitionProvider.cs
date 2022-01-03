using Volo.Abp.Settings;

namespace FreeERP.Settings
{
    public class FreeERPSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(FreeERPSettings.MySetting1));

            context.Add(new SettingDefinition(FreeERPSettings.HelpSetting,
                "true",
                isVisibleToClients: true)
            );
        }
    }
}
