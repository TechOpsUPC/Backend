using zenflicks_backend.events.Domain.Model.Aggregates;
using zenflicks_backend.events.Domain.Model.Queries;
using zenflicks_backend.events.Domain.Repositories;
using zenflicks_backend.events.Domain.Services;


namespace zenflicks_backend.events.Application.Internal.QueryServices;

public class EventQueryService(IEventRepository eventRepository) : IEventQueryService
{
    public async Task<Event?> HandleQueryId(GetEventByIdQuery query)
    {
        return await eventRepository.FindByIdAsync(query.Id);
    }

    public async Task<Event?> HandleQueryTittle(GetEventByTittleQuery query)
    {
        return await eventRepository.FindByTittleAsync(query.tittle);
    }
}