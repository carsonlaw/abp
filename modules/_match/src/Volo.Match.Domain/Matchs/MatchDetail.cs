using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using Volo.Match.Extensions;

namespace Volo.Match.Matchs
{
    public class MatchDetail :Entity
    {
        [NotNull] 
        public virtual Guid MatchID { get; protected set; }                
        public virtual int Sort { get; protected set; }
        public virtual Guid? TeamID { get; protected set; }        
        public virtual Guid? PlayerID { get; protected set; }

        
        protected internal MatchDetail([NotNull] Guid matchID, [NotNull] int sort, Guid? teamID, Guid? playerID)
        {
            MatchID = Check.NotNull(MatchID,nameof(MatchID));
            if(teamID.HasValue && playerID.HasValue)
                throw new ArgumentException($"teamID|playerID can not be all not null!", "teamID|playerID");
            if(!teamID.HasValue && !playerID.HasValue)
                throw new ArgumentException($"teamID|playerID can not be all null!", "teamID|playerID");
            Sort = Check.NotNull(sort,nameof(sort));
            TeamID = teamID;
            PlayerID = playerID;
        }

        public override object[] GetKeys()
        {
            return new object[]{MatchID,TeamID,PlayerID};
        }
        
    }
}
