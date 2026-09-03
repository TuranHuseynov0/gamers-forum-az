using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Application.DTOs.Responses.Forums
{
    public class ForumTopicResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string AuthorUsername { get; set; } = string.Empty;

        public int ReplyCount { get; set; }

        public int VoteScore { get; set; }

        public int ViewCount { get; set; }

        public bool IsPinned { get; set; }

        public bool IsLocked { get; set; }

        public DateTime CreatedAtUtc { get; set; }
    }
}
