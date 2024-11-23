using zenflicks_backend.forums.Domain.Model.Aggregates;
using zenflicks_backend.forums.Domain.Model.Queries;
using zenflicks_backend.forums.Domain.Repositories;
using zenflicks_backend.forums.Domain.Services;

namespace zenflicks_backend.forums.Application.Internal.QueryServices;

public class ForumQueryService(IForumRepository forumRepository)
    : IForumQueryService
{
    public async Task<Forum?> Handle(GetForumByIdQuery query)
    {
        return await forumRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Forum>> Handle(GetAllForumsQuery query)
    {
        return await forumRepository.ListAsync();
    }
}