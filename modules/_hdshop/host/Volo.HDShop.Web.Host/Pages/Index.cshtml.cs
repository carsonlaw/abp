using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Volo.HDShop.Pages
{
    public class IndexModel : HDShopPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}