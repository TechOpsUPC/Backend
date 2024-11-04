using zenflicks_backend.shared.domain.repositories;
using zenflicks_backend.shared.infrastructure.persistence.EFC.configuration;

namespace zenflicks_backend.shared.infrastructure.persistence.EFC.repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}