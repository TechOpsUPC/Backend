using zenflicks_backend.events.Domain.Model.Aggregates;
using zenflicks_backend.events.Domain.Model.Queries;

namespace zenflicks_backend.events.Domain.Services;

public interface IEventQueryService
{
    Task<Event?> HandleQueryId(GetEventByIdQuery query);
    
    Task<Event?> HandleQueryTittle(GetEventByTittleQuery query);
}