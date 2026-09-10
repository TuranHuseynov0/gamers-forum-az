namespace GamingCommunity.Application.DTOs.Requests.Forums
{
    public class CreateReplyRequest
    {
        public Guid UserId { get; set; }
        public Guid? ParentReplyId { get; set; } = null;
        public Guid TopicId { get; set; }
        public string ReplyContent { get; set; } = string.Empty;

    }
}
