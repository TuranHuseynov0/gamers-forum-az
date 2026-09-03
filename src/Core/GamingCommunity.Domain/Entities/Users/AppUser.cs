using GamingCommunity.Domain.Entities.Forum;
using GamingCommunity.Domain.Entities.Forums;
using Microsoft.AspNetCore.Identity;

namespace GamingCommunity.Domain.Entities.Users;

public class AppUser : IdentityUser<Guid>
{
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginAtUtc { get; set; }
    public ICollection<ForumTopic> Topics { get; set; } = new List<ForumTopic>();
    public ICollection<ForumReply> Replies { get; set; } = new List<ForumReply>();
    public ICollection<TopicVote> TopicVotes { get; set; } = new List<TopicVote>();
    public ICollection<ReplyVote> ReplyVotes { get; set; } = new List<ReplyVote>();
}
