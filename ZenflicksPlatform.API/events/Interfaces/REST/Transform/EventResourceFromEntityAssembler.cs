using zenflicks_backend.events.Domain.Model.Aggregates;
using zenflicks_backend.events.Interfaces.REST.Resources;

namespace zenflicks_backend.events.Interfaces.REST.Transform;

public class EventResourceFromEntityAssembler
{
    public static EventResource ToResourceFromEntity(Event entity) =>
        new EventResource(
            entity.Id,
            entity.contentId,
            entity.tittle,
            entity.description,
            entity.date,
            entity.address,
            entity.creatorId
        );
}