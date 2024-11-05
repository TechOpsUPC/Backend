using zenflicks_backend.users.Domain.Model.Aggregates;
using zenflicks_backend.users.Domain.Model.Commands;

namespace zenflicks_backend.users.Domain.Services;

public interface IUserCommandService
{
    Task<User?> Handle(CreateUserCommand command);
}