namespace zenflicks_backend.events.Interfaces.REST.Resources;

public record EventResource
(
    int Id,
    string contentId,
    string tittle,
    string description,
    string date,
    string address,
    string creatorId
);