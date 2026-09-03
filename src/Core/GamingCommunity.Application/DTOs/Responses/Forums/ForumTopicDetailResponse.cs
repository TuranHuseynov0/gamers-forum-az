using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Application.DTOs.Responses.Forums
{
    public class ForumTopicDetailResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string AuthorUsername { get; set; } = string.Empty;
        public int VoteScore { get; set; }

        public int ViewCount { get; set; }

        public bool IsPinned { get; set; }

        public bool IsLocked { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public IEnumerable<ForumReplyResponse> Replies { get; set; }
            = [];
    }
}
