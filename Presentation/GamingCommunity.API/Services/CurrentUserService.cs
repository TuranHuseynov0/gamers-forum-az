using GamingCommunity.Application.Services.Interfaces;
using System.Security.Claims;

namespace GamingCommunity.API.Services;

public class CurrentUserService(
    IHttpContextAccessor httpContextAccessor)
    : ICurrentUserService
{
    public Guid? UserId
    {
        get
        {
            var userIdValue = httpContextAccessor
                .HttpContext?
                .User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            return Guid.TryParse(userIdValue, out var userId)
                ? userId
                : null;
        }
    }

    public string? Username =>
        httpContextAccessor
            .HttpContext?
            .User
            .FindFirstValue(ClaimTypes.Name);

    public bool IsAuthenticated =>
        httpContextAccessor
            .HttpContext?
            .User
            .Identity?
            .IsAuthenticated == true;

    public IReadOnlyList<string> Roles =>
        httpContextAccessor
            .HttpContext?
            .User
            .FindAll(ClaimTypes.Role)
            .Select(x => x.Value)
            .ToList()
        ?? [];
}