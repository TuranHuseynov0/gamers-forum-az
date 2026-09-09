

using GamingCommunity.Domain.Entities.Forums;
using GamingCommunity.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Persistence.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Topic> ForumTopics => Set<Topic>();
    public DbSet<Reply> ForumReplies => Set<Reply>();
    public DbSet<Vote> TopicVotes => Set<Vote>();
    public DbSet<Category> ReplyVotes => Set<Category>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
