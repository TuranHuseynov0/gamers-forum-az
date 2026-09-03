using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Application.DTOs.Requests.Forums
{
    public class CreateForumReplyRequest
    {
        public string Content { get; set; } = string.Empty;
    }
}
