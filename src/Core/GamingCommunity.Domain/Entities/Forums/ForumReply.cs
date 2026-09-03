using GamingCommunity.Domain.Common;
using GamingCommunity.Domain.Entities.Forum;
using GamingCommunity.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Domain.Entities.Forums
{
    public class ForumReply : BaseEntity
    {
        public string Content { get; set; } = string.Empty;
        public Guid TopicId { get; set; }
        public ForumTopic Topic { get; set; } = null!;
        public Guid AuthorId { get; set; }
        public AppUser Author { get; set; } = null!;
        public ICollection<ReplyVote> Votes { get; set; } = new List<ReplyVote>();  
    }
}
