using GamingCommunity.Application.DTOs.Requests.Auth;
using GamingCommunity.Application.DTOs.Responses.ApiResponse;
using GamingCommunity.Application.DTOs.Responses.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthResponse>> RegisterAsync(RegisterRequest request);
        Task<ApiResponse<AuthResponse>> LoginAsync(LoginRequest request);
    }
}
