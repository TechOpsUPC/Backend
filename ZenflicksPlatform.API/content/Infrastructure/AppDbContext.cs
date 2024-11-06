using Microsoft.EntityFrameworkCore;
using zenflicks_backend.content.Domain.Model;

namespace zenflicks_backend.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Content> Contents { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
