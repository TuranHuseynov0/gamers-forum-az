using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Application.DTOs.Requests.Forums
{
    public class UpdateTopicRequest
    {
        public Guid RequestingUserId { get; set; }
        public Guid TopicId { get; set; }
        public string UpdateTitle { get; set; } = string.Empty;
        public string UpdateContent { get; set; } = string.Empty;
    }
}
