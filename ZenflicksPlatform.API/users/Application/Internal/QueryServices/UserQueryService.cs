using zenflicks_backend.users.Domain.Model.Aggregates;
using zenflicks_backend.users.Domain.Model.Queries;
using zenflicks_backend.users.Domain.Repositories;
using zenflicks_backend.users.Domain.Services;

namespace zenflicks_backend.users.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository)
    : IUserQueryService
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }

    public async Task<User?> Handle(GetUserByUsernameAndPasswordQuery query)
    {
        return await userRepository.FindByUsernameAndPasswordAsync(query.userName, query.password);
    }
}