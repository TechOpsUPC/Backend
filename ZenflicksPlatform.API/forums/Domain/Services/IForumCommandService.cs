using zenflicks_backend.forums.Domain.Model.Aggregates;
using zenflicks_backend.forums.Domain.Model.Commands;

namespace zenflicks_backend.forums.Domain.Services;

public interface IForumCommandService
{
 Task<Forum?> Handle(CreateForumCommand command);   
}