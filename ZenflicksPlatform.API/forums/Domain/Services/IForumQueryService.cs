using zenflicks_backend.forums.Domain.Model.Aggregates;
using zenflicks_backend.forums.Domain.Model.Queries;

namespace zenflicks_backend.forums.Domain.Services;

public interface IForumQueryService
{
    Task<Forum> Handle(GetForumByIdQuery query);
    
    Task<IEnumerable<Forum>> Handle(GetAllForumsQuery query);
}