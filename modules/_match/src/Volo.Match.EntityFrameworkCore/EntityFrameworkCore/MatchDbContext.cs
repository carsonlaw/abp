using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Match.Matchs;

namespace Volo.Match.EntityFrameworkCore
{
    [ConnectionStringName(MatchDbProperties.ConnectionStringName)]
    public class MatchDbContext : AbpDbContext<MatchDbContext>, IMatchDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public DbSet<Area> Areas { get; }
        public DbSet<Group> MatchGroups { get; }
        public DbSet<Volo.Match.Matchs.Match> Matchs { get; set; }

        public MatchDbContext(DbContextOptions<MatchDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureMatch();
        }
    }
}