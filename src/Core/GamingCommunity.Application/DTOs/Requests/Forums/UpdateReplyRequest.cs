namespace GamingCommunity.Application.DTOs.Requests.Forums
{
    public class UpdateReplyRequest
    {
        public Guid RequestingUserId { get; set; }
        public Guid ReplyId { get; set; }
        public string UpdateContent { get; set; } = string.Empty;
    }
}
