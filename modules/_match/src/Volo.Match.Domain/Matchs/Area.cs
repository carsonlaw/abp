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
    public class Area : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid PId { get; protected set; }
        [NotNull]
        public virtual string Name { get; protected set; }
        public virtual string Icon { get; protected set; }
    }
}
