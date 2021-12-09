using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Match.Matchs;

namespace Volo.Match.EntityFrameworkCore
{
    public static class MatchDbContextModelCreatingExtensions
    {
        public static void ConfigureMatch(
            this ModelBuilder builder,
            Action<MatchModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new MatchModelBuilderConfigurationOptions(
                MatchDbProperties.DbTablePrefix,
                MatchDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */
            builder.Entity<Area>(b => {
                b.ToTable(options.TablePrefix + "Areas", options.Schema);
                b.ConfigureByConvention();
                b.Property(q => q.PId);
                b.Property(q => q.Name).IsRequired().HasMaxLength(AreaConsts.MaxNameLength);
                b.Property(q => q.Icon).HasMaxLength(AreaConsts.MaxIconLength);

                b.HasIndex(q => q.PId);
            });
            builder.Entity<Group>(b => {
                b.ToTable(options.TablePrefix + "Groups", options.Schema);
                b.ConfigureByConvention();
                b.Property(q => q.MatchType).IsRequired().HasMaxLength(GroupConsts.MaxMatchTypeLength);
                b.Property(q => q.GroupType).IsRequired().HasMaxLength(GroupConsts.MaxGroupTypeLength);
                b.Property(q => q.AreaId);
                b.Property(q => q.Name).IsRequired().HasMaxLength(GroupConsts.MaxNameLength);
                b.Property(q => q.Icon).HasMaxLength(GroupConsts.MaxIconLength);

                b.HasIndex(q => q.AreaId);
            });
            builder.Entity<GroupSeason>(b => {
                b.ToTable(options.TablePrefix + "GroupSeasons", options.Schema);
                b.ConfigureByConvention();
                b.Property(q => q.GroupId);
                b.Property(q => q.Season).IsRequired().HasMaxLength(GroupSeasonConsts.MaxSeasonLength);

                b.HasIndex(q => q.GroupId);
            });

            builder.Entity<Volo.Match.Matchs.Match>(b=>{
                b.ToTable(options.TablePrefix + "Matchs", options.Schema);
                b.ConfigureByConvention();
                b.Property(q=>q.Name).IsRequired().HasMaxLength(MatchConsts.MaxNameLength);
                b.Property(q=>q.Slug).IsRequired().HasMaxLength(MatchConsts.MaxSulgLength);
                b.Property(q=>q.Time).IsRequired();

                b.HasIndex(q=>q.Slug);
            });
        }
    }
}