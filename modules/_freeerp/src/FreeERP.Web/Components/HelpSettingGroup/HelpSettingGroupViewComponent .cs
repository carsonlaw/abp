using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using FreeERP.Settings;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace FreeERP.Web.Components
{
    [Widget(
        ScriptFiles = new string[] { "/Components/HelpSettingGroup/Default.js" }
    )]
    public class HelpSettingGroupViewComponent : AbpViewComponent
    {
        public virtual IViewComponentResult Invoke()
        {
            var model = new HelpSettingDto();
            return View("~/Components/HelpSettingGroup/Default.cshtml", model);
        }
    }
}