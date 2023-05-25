using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace FreeERP.Pages;

public class IndexModel : FreeERPPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
