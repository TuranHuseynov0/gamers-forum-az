namespace GamingCommunity.Application.Services.Interfaces;

public interface ICurrentUserService
{
    Guid? UserId { get; }

    string? Username { get; }

    bool IsAuthenticated { get; }

    IReadOnlyList<string> Roles { get; }
}