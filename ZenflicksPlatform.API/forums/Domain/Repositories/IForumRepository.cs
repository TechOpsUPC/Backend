using zenflicks_backend.forums.Domain.Model.Aggregates;
using zenflicks_backend.shared.domain.repositories;

namespace zenflicks_backend.forums.Domain.Repositories;

public interface IForumRepository : IBaseRepository<Forum>
{
    Task<Forum?> FindByIdAsync(int id);
    
    Task<IEnumerable<Forum>> GetAllAsync();
    
}