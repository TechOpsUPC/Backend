using zenflicks_backend.events.Domain.Model.Aggregates;
using zenflicks_backend.events.Domain.Model.Commands;

namespace zenflicks_backend.events.Domain.Services;

public interface IEventCommandService
{
    Task<Event?> HandleCommand(CreateEventCommand command);
}