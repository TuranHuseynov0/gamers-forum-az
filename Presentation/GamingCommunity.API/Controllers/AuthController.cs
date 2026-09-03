using GamingCommunity.Application.DTOs.Requests.Auth;
using GamingCommunity.Application.DTOs.Responses.ApiResponse;
using GamingCommunity.Application.DTOs.Responses.Auth;
using GamingCommunity.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingCommunity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<AuthResponse>>> Register (RegisterRequest request)
        {
            var response = await authService.RegisterAsync(request);

            return StatusCode(response.StatusCode, response);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<AuthResponse>>> Login(LoginRequest request)
        {
            var response = await authService.LoginAsync(request);

            return StatusCode(response.StatusCode, response);
        }
    }
}
