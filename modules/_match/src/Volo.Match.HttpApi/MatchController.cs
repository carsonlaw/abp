using Volo.Match.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Match
{
    public abstract class MatchController : AbpController
    {
        protected MatchController()
        {
            LocalizationResource = typeof(MatchResource);
        }
    }
}
