namespace zenflicks_backend.events.Domain.Model.Commands;

public record CreateEventCommand ( string contentId,
string tittle,
string description,
string date,
string address,
string creatorId
    );