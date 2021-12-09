using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Match.EntityFrameworkCore;

namespace Volo.Match.Matchs
{
    public class EFCoreMatchRepository : EfCoreRepository<MatchDbContext, Match>, IMatchRepository
    {
        public EFCoreMatchRepository(IDbContextProvider<MatchDbContext> dbContextProvider):base(dbContextProvider)
        {

        }
        public async Task<Match> GetBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(slug, nameof(slug));

            var Match = await GetAsync(
                                    x => x.Slug.ToLower() == slug, 
                                    cancellationToken: GetCancellationToken(cancellationToken));

            return Match;
        }

        public async Task<bool> SlugExistsAsync(string slug, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(slug, nameof(slug));
            
            return await (await GetQueryableAsync()).AnyAsync(x => x.Slug.ToLower() == slug,
                GetCancellationToken(cancellationToken));
        }
    }
}