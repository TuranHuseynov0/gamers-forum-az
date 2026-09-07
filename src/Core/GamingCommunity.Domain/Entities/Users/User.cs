using GamingCommunity.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string? ProfileImagePath { get; set; }
        public string? BannerImagePath { get; set; }
    }
}
