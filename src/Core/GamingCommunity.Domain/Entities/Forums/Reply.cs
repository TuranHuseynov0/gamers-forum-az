using GamingCommunity.Domain.Common;
using GamingCommunity.Domain.Entities.Users;

namespace GamingCommunity.Domain.Entities.Forums
{
    public class Reply : BaseEntity
    {
        public string Content { get; set; } = string.Empty;
        public int VoteScore { get; set; } = 0;

        // Topic relation
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; } = null!;

        // Author relation
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        // Self relation
        public Guid? ParentReplyId { get; set; }
        public Reply? ParentReply { get; set; }
        public ICollection<Reply> ChildReplies { get; set; } = new List<Reply>();
    }
}
