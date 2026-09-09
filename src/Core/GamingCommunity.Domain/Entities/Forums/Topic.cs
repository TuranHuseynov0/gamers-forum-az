using GamingCommunity.Domain.Common;
using GamingCommunity.Domain.Entities.Users;

namespace GamingCommunity.Domain.Entities.Forums
{
    public class Topic : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int VoteScore { get; set; } = 0;


        //Category Relation
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;


        //Author Relation
        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;


        // One topic to many reply
        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}
