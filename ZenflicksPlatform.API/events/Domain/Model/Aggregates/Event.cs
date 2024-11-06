using zenflicks_backend.events.Domain.Model.Commands;

namespace zenflicks_backend.events.Domain.Model.Aggregates;

public class Event
{
    public int Id { get; private set; }
    public string tittle { get; private set; }
    public string description { get; private set; }
    public string date { get; private set; }
    public string address { get; private set; }
    public string creatorId { get; private set; }
    public string contentId { get; private set; }

    protected Event()
    {
        this.tittle = string.Empty;
        this.description = string.Empty;
        this.date = string.Empty;
        this.address = string.Empty;
        this.creatorId = string.Empty;
        this.contentId = string.Empty;
    }

    public Event(CreateEventCommand command)
    {
        this.tittle = command.tittle;
        this.description = command.description;
        this.date = command.date;
        this.address = command.address;
        this.creatorId = command.creatorId;
        this.contentId = command.contentId;
    }
    
}