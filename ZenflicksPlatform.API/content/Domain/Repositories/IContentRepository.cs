using zenflicks_backend.content.Domain.Model;

namespace zenflicks_backend.content.Domain.Repositories
{
    public interface IContentRepository
    {
        Task AddAsync(Content content);
        Task<Content> GetByIdAsync(int id);
    }
}