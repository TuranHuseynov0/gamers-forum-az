using GamingCommunity.Domain.Common;
using GamingCommunity.Domain.Entities.Users;
using GamingCommunity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Domain.Entities.Forums
{
    public class ReplyVote : BaseEntity
    {
        public Guid ReplyId { get; set; }
        public ForumReply Reply { get; set; } = null!;
        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;
        public VoteType VoteType { get; set; }
    }
}
