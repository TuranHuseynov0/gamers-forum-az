using GamingCommunity.Application.DTOs.Requests.Forums;
using GamingCommunity.Application.DTOs.Responses.ApiResponse;
using GamingCommunity.Application.DTOs.Responses.Forums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Application.Services.Interfaces
{
    public interface IForumService
    {
        Task<ApiResponse<ForumTopicResponse>> CreateTopicAsync(
            CreateForumTopicRequest request,
            CancellationToken cancellationToken = default);

        Task<ApiResponse<ForumReplyResponse>> CreateReplyAsync(
            Guid topicId,
            CreateForumReplyRequest request,
            CancellationToken cancellationToken = default);

        Task<ApiResponse<int>> VoteOnTopicAsync(
            Guid topicId,
            VoteRequest request,
            CancellationToken cancellationToken = default);

        Task<ApiResponse<int>> VoteOnReplyAsync(
            Guid replyId,
            VoteRequest request,
            CancellationToken cancellationToken = default);
    }
}
