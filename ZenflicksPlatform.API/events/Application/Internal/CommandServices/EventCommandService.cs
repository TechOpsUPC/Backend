using zenflicks_backend.events.Domain.Model.Aggregates;
using zenflicks_backend.events.Domain.Model.Commands;
using zenflicks_backend.events.Domain.Repositories;
using zenflicks_backend.events.Domain.Services;
using zenflicks_backend.shared.domain.repositories;


namespace zenflicks_backend.events.Application.Internal.CommandServices;

public class EventCommandService(IEventRepository eventRepository, IUnitOfWork unitOfWork)
    :IEventCommandService
{
    public async Task<Event?> HandleCommand(CreateEventCommand command)
    {
        var Event = await eventRepository.FindByTittleAsync(command.tittle);
        if(Event != null) throw new Exception("Event with this tittle not found");
        Event = new Event(command);
        try
        {
            await eventRepository.AddAsync(Event);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return Event;
    }
}