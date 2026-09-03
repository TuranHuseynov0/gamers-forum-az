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
        public VoteType VoteType { get; set; }
    }
}
