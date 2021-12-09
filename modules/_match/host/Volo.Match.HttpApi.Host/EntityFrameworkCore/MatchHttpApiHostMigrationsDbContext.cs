using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.Match.EntityFrameworkCore
{
    public class MatchHttpApiHostMigrationsDbContext : AbpDbContext<MatchHttpApiHostMigrationsDbContext>
    {
        public MatchHttpApiHostMigrationsDbContext(DbContextOptions<MatchHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureMatch();
        }
    }
}
