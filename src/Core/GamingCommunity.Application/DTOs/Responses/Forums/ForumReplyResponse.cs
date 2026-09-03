using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Application.DTOs.Responses.Forums
{
    public class ForumReplyResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string AuthorUsername { get; set; } = string.Empty;
        public int VoteScore { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}   
