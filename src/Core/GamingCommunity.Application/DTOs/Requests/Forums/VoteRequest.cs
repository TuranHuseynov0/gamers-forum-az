using GamingCommunity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Application.DTOs.Requests.Forums
{
    public class VoteRequest
    {
        public Guid UserId { get; set; }
        public VoteType VoteType { get; set; }
        public Guid TargetId { get; set; }
        public int Value { get; set; }
    }
}
