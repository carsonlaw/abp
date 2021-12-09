using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Match.Extensions;

namespace Volo.Match.Markets
{
    public class Market : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        [NotNull] 
        public virtual string Name { get; protected set; }

        [NotNull] 
        public virtual string Slug { get; protected set; }

        [NotNull] 
        public virtual DateTime Time { get; protected set; }

        public virtual Guid? TenantId { get; protected set; }
        
        protected internal Market(Guid id, [NotNull] string name, [NotNull] string slug, [CanBeNull] Guid? tenantId = null) : base(id)
        {
            SetName(name);
            SetSlug(slug);
            TenantId = tenantId;
        }
        
        public virtual void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), MarketConsts.MaxNameLength);
        }

        public virtual void SetSlug(string slug)
        {
            Check.NotNullOrWhiteSpace(slug, nameof(slug), MarketConsts.MaxNameLength);

            Slug = slug.NormalizeSlug();
        }
    }
}
