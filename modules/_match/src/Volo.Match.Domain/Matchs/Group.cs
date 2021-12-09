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
    public class Group : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string MatchType { get; protected set; }
        [NotNull]
        public virtual string GroupType { get; protected set; }
        public virtual Guid AreaId { get; protected set; }
        [NotNull]
        public virtual string Name { get; protected set; }
        [NotNull]
        public virtual string Icon { get; protected set; }

        public Group()
        {
            
        }
    }
}
