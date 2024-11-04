using zenflicks_backend.shared.domain.repositories;
using zenflicks_backend.users.Domain.Model.Aggregates;

namespace zenflicks_backend.users.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByIdAsync(string id);
    
    Task<User?> FindByUsernameAndPasswordAsync(string username, string password);
}