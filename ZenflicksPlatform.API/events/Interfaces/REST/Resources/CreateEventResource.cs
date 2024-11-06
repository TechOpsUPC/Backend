namespace zenflicks_backend.events.Interfaces.REST.Resources;

public record CreateEventResource(string contentId,
    string tittle,
    string description,
    string date,
    string address,
    string creatorId);