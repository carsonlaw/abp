using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Volo.Match.Pages
{
    public class IndexModel : MatchPageModel
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