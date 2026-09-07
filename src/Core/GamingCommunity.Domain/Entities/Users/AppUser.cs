using Microsoft.AspNetCore.Identity;

namespace GamingCommunity.Domain.Entities.Users;

public class AppUser : IdentityUser<Guid>
{
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginAtUtc { get; set; }
}
