using GamingCommunity.Domain.Common;

namespace GamingCommunity.Domain.Entities.Forums
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public ICollection<Topic> Topics { get; set; } = new List<Topic>();
    }
}
