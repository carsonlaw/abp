using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Match.Extensions;

namespace Volo.Match.Players
{
    public class Team : FullAuditedAggregateRoot<Guid>
    {
        [NotNull] 
        public virtual string Name { get; protected set; }

        [NotNull] 
        public virtual string Slug { get; protected set; }

        
        protected internal Team(Guid id, [NotNull] string name, [NotNull] string slug) : base(id)
        {
            SetName(name);
            SetSlug(slug);
        }
        
        public virtual void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), TeamConsts.MaxNameLength);
        }

        public virtual void SetSlug(string slug)
        {
            Check.NotNullOrWhiteSpace(slug, nameof(slug), TeamConsts.MaxSulgLength);

            Slug = slug.NormalizeSlug();
        }
    }
}
