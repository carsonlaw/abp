using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Volo.Match.Matchs
{
    public interface IMatchRepository : IRepository<Match>
    {
        Task<Match> GetBySlugAsync(string slug, CancellationToken cancellationToken = default);
        
        Task<bool> SlugExistsAsync(string slug, CancellationToken cancellationToken = default);
    }
}