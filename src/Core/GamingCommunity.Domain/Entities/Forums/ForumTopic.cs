using GamingCommunity.Domain.Common;
using GamingCommunity.Domain.Entities.Forums;
using GamingCommunity.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Domain.Entities.Forum
{
    public class ForumTopic : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public AppUser Author { get; set; } = null!;
        public bool IsLocked { get; set; }
        public bool IsPinned { get; set; }
        public int ViewCount { get; set; }
        public ICollection<ForumReply> Replies { get; set; } = new List<ForumReply>();
        public ICollection<TopicVote> Votes { get; set; } = new List<TopicVote>();
    }
}
