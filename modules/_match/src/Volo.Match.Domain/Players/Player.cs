using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Match.Extensions;

namespace Volo.Match.Players
{
    public class Player : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid? TeamId { get; protected set; }
        [NotNull] 
        public virtual string Name { get; protected set; }

        [NotNull] 
        public virtual string Slug { get; protected set; }

        
        protected internal Player(Guid id, 
            Guid? teamId,[NotNull] string name, [NotNull] string slug) : base(id)
        {
            TeamId = teamId;
            SetName(name);
            SetSlug(slug);
        }
        
        public virtual void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), PlayerConsts.MaxNameLength);
        }

        public virtual void SetSlug(string slug)
        {
            Check.NotNullOrWhiteSpace(slug, nameof(slug), PlayerConsts.MaxNameLength);

            Slug = slug.NormalizeSlug();
        }
    }
}
