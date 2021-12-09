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
    public class GroupSeason : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual Guid GroupId { get; protected set; }
        [NotNull]
        public virtual string Season { get; protected set; }

        
    }
}
