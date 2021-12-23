
using System.Threading.Tasks;
using FreeERP.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.Extensions.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Layout;

namespace FreeERP.Web.Pages
{
    public class FreeERPPageBase : Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        [RazorInject] public IStringLocalizer<FreeERPResource> L { get; set; }
        [RazorInject] public IPageLayout PageLayout { get; set; }

        public override Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}