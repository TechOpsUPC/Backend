using zenflicks_backend.events.Domain.Model.Aggregates;
using zenflicks_backend.shared.domain.repositories;

namespace zenflicks_backend.events.Domain.Repositories;

public interface IEventRepository : IBaseRepository<Event>
{
    Task<Event?> FindByIdAsync(int id);
    
    Task<Event?> FindByTittleAsync(string tittle);
    
}