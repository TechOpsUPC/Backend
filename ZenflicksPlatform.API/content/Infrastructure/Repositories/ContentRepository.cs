using zenflicks_backend.content.Domain.Model;
using zenflicks_backend.content.Domain.Repositories;
using zenflicks_backend.Infrastructure;  // Usar el espacio de nombres correcto

namespace zenflicks_backend.content.Infrastructure.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly AppDbContext _dbContext;  // Verifica que sea ApplicationDbContext y no AppDbContext

        public ContentRepository(AppDbContext dbContext)  // Verifica que se esté inyectando ApplicationDbContext
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Content content)
        {
            await _dbContext.Contents.AddAsync(content);  // Asegúrate de que Contents existe en ApplicationDbContext
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Content> GetByIdAsync(int id)
        {
            return await _dbContext.Contents.FindAsync(id);  // Asegúrate de que Contents esté en ApplicationDbContext
        }
    }
}