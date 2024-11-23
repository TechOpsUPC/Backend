using Microsoft.EntityFrameworkCore;
using zenflicks_backend.forums.Domain.Model.Aggregates;
using zenflicks_backend.forums.Domain.Repositories;
using zenflicks_backend.shared.infrastructure.persistence.EFC.configuration;
using zenflicks_backend.shared.infrastructure.persistence.EFC.repositories;

namespace zenflicks_backend.forums.Infrastructure.Repositories;

public class ForumRepository : BaseRepository<Forum>, IForumRepository
{
    public ForumRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Forum?> FindByIdAsync(int id)
    { 
        return await Context.Set<Forum>().FirstOrDefaultAsync(f => f.Id == id);
    }

    public Task<Forum?> FindByTitleAsync(string title)
    {
        return Context.Set<Forum>().FirstOrDefaultAsync(f => f.Title == title);
    }
}