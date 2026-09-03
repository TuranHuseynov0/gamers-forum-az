using GamingCommunity.Application.DTOs.Responses.Auth;
using GamingCommunity.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Application.Services.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> GenerateTokenAsync(AppUser user, CancellationToken cancellationToken = default);
    }
}
