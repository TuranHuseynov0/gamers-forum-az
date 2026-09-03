
using GamingCommunity.Domain.Entities.Forum;
using GamingCommunity.Domain.Entities.Forums;
using GamingCommunity.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Persistence.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<ForumTopic> ForumTopics => Set<ForumTopic>();
    public DbSet<ForumReply> ForumReplies => Set<ForumReply>();
    public DbSet<TopicVote> TopicVotes => Set<TopicVote>();
    public DbSet<ReplyVote> ReplyVotes => Set<ReplyVote>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
