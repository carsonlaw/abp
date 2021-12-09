using Volo.Match.Localization;
using Volo.Abp.Application.Services;

namespace Volo.Match
{
    public abstract class MatchAppService : ApplicationService
    {
        protected MatchAppService()
        {
            LocalizationResource = typeof(MatchResource);
            ObjectMapperContext = typeof(MatchApplicationModule);
        }
    }
}
