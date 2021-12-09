using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Match.Extensions;
using Volo.Match.Players;

namespace Volo.Match.Matchs
{
    /// <summary>
    /// 
    /// </summary>
    public class Match : FullAuditedAggregateRoot<Guid>
    {
        [NotNull] 
        public virtual string Name { get; protected set; }

        [NotNull] 
        public virtual string Slug { get; protected set; }

        [NotNull] 
        public virtual DateTimeOffset Time { get; protected set; }

        public IEnumerable<Team> Teams {get; protected set;}
        
        protected internal Match(Guid id, [NotNull] string name, [NotNull] string slug, [NotNull] DateTimeOffset time) : base(id)
        {
            SetName(name);
            SetSlug(slug);
            SetTime(time);
        }
        
        public virtual void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), MatchConsts.MaxNameLength);
        }

        public virtual void SetSlug(string slug)
        {
            Check.NotNullOrWhiteSpace(slug, nameof(slug), MatchConsts.MaxSulgLength);
            Slug = slug.NormalizeSlug();
        }
        public virtual void SetTime(DateTimeOffset time)
        {
            Time = Check.NotNull(time, nameof(time));
        }
    }
}
