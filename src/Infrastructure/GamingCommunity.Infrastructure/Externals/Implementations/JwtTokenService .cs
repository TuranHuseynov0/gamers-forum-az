using GamingCommunity.Application.DTOs.Responses.Auth;
using GamingCommunity.Application.Services.Interfaces;
using GamingCommunity.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Infrastructure.Externals.Implementations
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<AppUser> _userManager;

        public JwtTokenService(
            IOptions<JwtSettings> jwtOptions,
            UserManager<AppUser> userManager)
        {
            _jwtSettings = jwtOptions.Value;
            _userManager = userManager;
        }

        public async Task<string> GenerateTokenAsync(
            AppUser user,
            CancellationToken cancellationToken = default)
        {
            var expiresAtUtc =
                DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes);

            var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName ?? string.Empty),
            new(ClaimTypes.Email, user.Email ?? string.Empty),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expiresAtUtc,
                signingCredentials: credentials);

            var accessToken =
                new JwtSecurityTokenHandler().WriteToken(token);

            return accessToken;
        }
    }
}
