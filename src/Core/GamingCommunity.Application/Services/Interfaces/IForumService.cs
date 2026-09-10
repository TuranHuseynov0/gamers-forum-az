using GamingCommunity.Application.DTOs.Requests.Forums;
using GamingCommunity.Application.DTOs.Responses.ApiResponse;
using GamingCommunity.Domain.Entities.Forums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Application.Services.Interfaces
{
    public interface IForumService
    {
        //Topic
        Task<Topic> CreateTopicAsync (CreateTopicRequest request);
        Task<Topic> EditTopicAsync(UpdateTopicRequest request);
        Task RemoveTopicAsync(Guid topicId, Guid requestingUserId);
        Task<Topic> GetTopicByIdAsync(Guid topicId);
        Task<IReadOnlyList<Topic>> GetTopicsByCategoryAsync(Guid categoryId, int page = 1, int pageSize = 20);

        //Reply
        Task<Reply> CreateReplyAsync(CreateReplyRequest request);
        Task<Reply> EditReplyAsync(UpdateReplyRequest request);
        Task RemoveReplyAsync(Guid replyId, Guid requestingUserId);
        Task<IReadOnlyList<Reply>> GetRepliesByTopicAsync(Guid topicId);

        //VoteScore
        Task<int> VoteAsync(VoteRequest request);
    }
}
