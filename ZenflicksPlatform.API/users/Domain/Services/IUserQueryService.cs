using zenflicks_backend.users.Domain.Model.Aggregates;
using zenflicks_backend.users.Domain.Model.Queries;

namespace zenflicks_backend.users.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByUsernameAndPasswordQuery query);
}