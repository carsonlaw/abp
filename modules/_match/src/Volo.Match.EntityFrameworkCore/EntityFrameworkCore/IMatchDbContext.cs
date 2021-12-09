using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Match.Matchs;

namespace Volo.Match.EntityFrameworkCore
{
    [ConnectionStringName(MatchDbProperties.ConnectionStringName)]
    public interface IMatchDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Area> Areas { get; }
        DbSet<Group> MatchGroups { get; }
        DbSet<Matchs.Match> Matchs {get;}
    }
}