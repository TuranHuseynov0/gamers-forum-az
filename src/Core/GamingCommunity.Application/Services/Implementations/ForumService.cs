using GamingCommunity.Application.Common.Exceptions;
using GamingCommunity.Application.DTOs.Requests.Forums;
using GamingCommunity.Application.Services.Interfaces;
using GamingCommunity.Domain.Entities.Forums;
using GamingCommunity.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Application.Services.Implementations;

public class ForumService(AppDbContext context) : IForumService
{
    //Topic
    public async Task<Topic> CreateTopicAsync(CreateTopicRequest request)
    {
        var categoryExists = await context.Categories
            .AnyAsync(c => c.Id == request.CategoryId);

        if (!categoryExists)
            throw new NotFoundException(nameof(Category), request.CategoryId);

        var topic = new Topic
        {
            Title = request.Title,
            Content = request.Content,
            CategoryId = request.CategoryId,
            UserId = request.UserId,
        };

        
    }

    public async Task<Topic> EditTopicAsync(UpdateTopicRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Reply> CreateReplyAsync(CreateReplyRequest request)
    {
        throw new NotImplementedException();
    }

    

    public Task<Reply> EditReplyAsync(UpdateReplyRequest request)
    {
        throw new NotImplementedException();
    }

    

    public Task<IReadOnlyList<Reply>> GetRepliesByTopicAsync(Guid topicId)
    {
        throw new NotImplementedException();
    }

    public Task<Topic> GetTopicByIdAsync(Guid topicId)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Topic>> GetTopicsByCategoryAsync(Guid categoryId, int page = 1, int pageSize = 20)
    {
        throw new NotImplementedException();
    }

    public Task RemoveReplyAsync(Guid replyId, Guid requestingUserId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveTopicAsync(Guid topicId, Guid requestingUserId)
    {
        throw new NotImplementedException();
    }

    public Task<int> VoteAsync(VoteRequest request)
    {
        throw new NotImplementedException();
    }
}