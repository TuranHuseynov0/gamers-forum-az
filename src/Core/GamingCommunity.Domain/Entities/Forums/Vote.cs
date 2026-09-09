using GamingCommunity.Domain.Common;
using GamingCommunity.Domain.Entities.Users;
using GamingCommunity.Domain.Enums;

namespace GamingCommunity.Domain.Entities.Forums
{
    public class Vote : BaseEntity
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;

        public VoteType TargetType { get; set; }
        public Guid TargetId { get; set; }   // Topic.Id ya da Reply.Id

        public int Value { get; set; }       // +1 ya da -1
    }
}
