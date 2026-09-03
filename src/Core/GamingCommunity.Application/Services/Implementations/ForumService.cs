using GamingCommunity.Application.DTOs.Requests.Forums;
using GamingCommunity.Application.DTOs.Responses.ApiResponse;
using GamingCommunity.Application.DTOs.Responses.Forums;
using GamingCommunity.Application.Services.Interfaces;
using GamingCommunity.Domain.Entities.Forum;
using GamingCommunity.Domain.Entities.Forums;
using GamingCommunity.Domain.Enums;
using GamingCommunity.Persistence.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace GamingCommunity.Application.Services.Implementations;

public class ForumService(
    IRepository<ForumTopic> topicRepository,
    IRepository<ForumReply> replyRepository,
    IRepository<TopicVote> topicVoteRepository,
    IRepository<ReplyVote> replyVoteRepository,
    IRepository<VoteResponse> score,
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService)
    : IForumService
{
    public async Task<ApiResponse<ForumTopicResponse>> CreateTopicAsync(
        CreateForumTopicRequest request,
        CancellationToken cancellationToken = default)
    {
        if (!currentUserService.IsAuthenticated ||
            currentUserService.UserId is null)
        {
            return ApiResponse<ForumTopicResponse>.FailResponse(
                "Unauthorized.",
                401);
        }

        var topic = new ForumTopic
        {
            Title = request.Title.Trim(),
            Content = request.Content.Trim(),
            AuthorId = currentUserService.UserId.Value
        };

        await topicRepository.AddAsync(
            topic,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(
            cancellationToken);

        var response = new ForumTopicResponse
        {
            Id = topic.Id,
            Title = topic.Title,
            AuthorUsername = currentUserService.Username ?? string.Empty,
            ReplyCount = 0,
            VoteScore = 0,
            ViewCount = topic.ViewCount,
            IsPinned = topic.IsPinned,
            IsLocked = topic.IsLocked,
            CreatedAtUtc = topic.CreatedAtUtc
        };

        return ApiResponse<ForumTopicResponse>.SuccessResponse(
            response,
            "Forum topic created successfully.",
            201);
    }


    public async Task<ApiResponse<ForumReplyResponse>> CreateReplyAsync(
        Guid topicId,
        CreateForumReplyRequest request,
        CancellationToken cancellationToken = default)
    {
        var userId = currentUserService.UserId;

        if (!currentUserService.IsAuthenticated || userId is null)
        {
            return ApiResponse<ForumReplyResponse>.FailResponse(
                "Unauthorized.",
                401);
        }

        var topic = await topicRepository.GetByIdAsync(
        topicId,
        cancellationToken);

        if(topic is null)
        {
            return ApiResponse<ForumReplyResponse>.FailResponse(
                "Forum topic not found.",
                404);
        }

        if (topic.IsLocked)
        {
            return ApiResponse<ForumReplyResponse>.FailResponse(
                "Forum topic is locked. You cannot reply to this topic.",
                403);
        }

        var reply = new ForumReply
        {
            Content = request.Content.Trim(),
            TopicId = topicId,
            AuthorId = userId.Value
        };

        await replyRepository.AddAsync(reply,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var response = new ForumReplyResponse
        {
            Id = reply.Id,
            Content = reply.Content,
            AuthorUsername = currentUserService.Username ?? string.Empty,
            VoteScore = 0,
            CreatedAtUtc = reply.CreatedAtUtc
        };

        return ApiResponse<ForumReplyResponse>.SuccessResponse(
            response,
            "Forum reply created successfully.",
            201);
    }

    public async Task<ApiResponse<int>> VoteOnTopicAsync(
        Guid topicId,
        VoteRequest request,
        CancellationToken cancellationToken = default)
    {
        var userId = currentUserService.UserId;

        if (!currentUserService.IsAuthenticated ||
            userId is null)
        {
            return await Task.FromResult(
                ApiResponse<int>.FailResponse(
                    "Unauthorized.",
                    401));
        }

        var topic = await topicRepository.GetByIdAsync(
            topicId,
            cancellationToken);

        if(topic is null)
        {
            return await Task.FromResult(
                ApiResponse<int>.FailResponse(
                    "Forum topic not found.",
                    404));
        }

        var existingVotes = await topicVoteRepository.FindAsync(
            v => v.TopicId == topicId && v.UserId == userId.Value,
            cancellationToken);

        var existingVote = existingVotes.FirstOrDefault();

        if (existingVote is null)
        {
            var newVote = new TopicVote
            {
                TopicId = topicId,
                UserId = userId.Value,
                VoteType = request.VoteType
            };

            await topicVoteRepository.AddAsync(newVote, cancellationToken);
        }
        else if (existingVote.VoteType == request.VoteType)
        {
            topicVoteRepository.Remove(existingVote);
        }
        else
        {
            existingVote.VoteType = request.VoteType;
            topicVoteRepository.Update(existingVote);
        }

        await unitOfWork.SaveChangesAsync();
        
        var allVotes = await topicVoteRepository.FindAsync(
            v => v.TopicId == topicId,
            cancellationToken);

        var score = allVotes.Sum(v => (int)v.VoteType);

        return ApiResponse<int>.SuccessResponse(score, "Vote registered.", 200);
    }

    public Task<ApiResponse<int>> VoteOnReplyAsync(
        Guid replyId,
        VoteRequest request,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}