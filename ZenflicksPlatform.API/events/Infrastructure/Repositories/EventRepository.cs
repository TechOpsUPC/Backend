using Microsoft.EntityFrameworkCore;
using zenflicks_backend.events.Domain.Model.Aggregates;
using zenflicks_backend.events.Domain.Repositories;
using zenflicks_backend.shared.infrastructure.persistence.EFC.configuration;
using zenflicks_backend.shared.infrastructure.persistence.EFC.repositories;

namespace zenflicks_backend.events.Infrastructure.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Event?> FindByIdAsync(int id)
    {
        return await Context.Set<Event>().FirstOrDefaultAsync(u=>u.Id == id);
    }

    public async Task<Event?> FindByTittleAsync(string tittle)
    {
        return await Context.Set<Event>().FirstOrDefaultAsync(u=> u.tittle == tittle);
    }
}