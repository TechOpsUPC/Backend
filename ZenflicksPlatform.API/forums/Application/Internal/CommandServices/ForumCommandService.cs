using zenflicks_backend.forums.Domain.Model.Aggregates;
using zenflicks_backend.forums.Domain.Model.Commands;
using zenflicks_backend.forums.Domain.Repositories;
using zenflicks_backend.forums.Domain.Services;
using zenflicks_backend.shared.domain.repositories;

namespace zenflicks_backend.forums.Application.Internal.CommandServices;

public class ForumCommandService (IForumRepository forumRepository, IUnitOfWork unitOfWork)
    : IForumCommandService
{
    public async Task<Forum?> Handle(CreateForumCommand command)
    {
        var forum = await forumRepository.FindByTitleAsync(command.Title);
        if(forum != null) throw new Exception("Forum with this title already exists");
        forum = new Forum(command);
        try
        {
            await forumRepository.AddAsync(forum);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return forum;
    }
}