
using System.Threading.Tasks;
using FreeERP.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.Extensions.Localization;

namespace FreeERP.Web.Pages
{
    public class FreeERPPageBase : Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        [RazorInject] public IStringLocalizer<FreeERPResource> L { get; set; }

        public override Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}