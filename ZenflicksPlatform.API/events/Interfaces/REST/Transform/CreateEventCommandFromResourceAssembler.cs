using zenflicks_backend.events.Domain.Model.Commands;
using zenflicks_backend.events.Interfaces.REST.Resources;

namespace zenflicks_backend.events.Interfaces.REST.Transform;

public static class CreateEventCommandFromResourceAssembler
{
    public static CreateEventCommand 
        ToCommandFromResource(CreateEventResource resource) =>
        new CreateEventCommand( 
            resource.contentId,
            resource.tittle,
            resource.description,
            resource.date,
            resource.address,
            resource.creatorId
        );
}