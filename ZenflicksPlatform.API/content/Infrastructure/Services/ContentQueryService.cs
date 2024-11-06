namespace zenflicks_backend.content.Infrastructure.Services
{
    using zenflicks_backend.content.Domain.Model.Queries;
    using zenflicks_backend.content.Domain.Model;
    using zenflicks_backend.content.Domain.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ContentQueryService : IContentQueryService
    {
        public async Task<Content> Handle(GetContentByIdQuery query)
        {
            // Lógica para obtener contenido por ID
            var content = new Content
            {
                Id = query.Id,
                Title = "Sample Title",
                Genre = "Sample Genre",
                Description = "Sample Description",
                ReleaseDate = DateTime.Now,
                Director = "Sample Director",
                Duration = TimeSpan.FromMinutes(120)
            };
            return content;
        }

        public async Task<IEnumerable<Content>> Handle(GetContentByTitleAndGenreQuery query)
        {
            // Lógica para obtener contenidos por título y género
            var contentList = new List<Content>
            {
                new Content
                {
                    Id = 1,
                    Title = "Sample Title 1",
                    Genre = "Action",
                    Description = "Action movie",
                    ReleaseDate = DateTime.Now,
                    Director = "Director 1",
                    Duration = TimeSpan.FromMinutes(90)
                },
                new Content
                {
                    Id = 2,
                    Title = "Sample Title 2",
                    Genre = "Comedy",
                    Description = "Comedy movie",
                    ReleaseDate = DateTime.Now,
                    Director = "Director 2",
                    Duration = TimeSpan.FromMinutes(100)
                }
            };

            return contentList.Where(c => (string.IsNullOrEmpty(query.Title) || c.Title.Contains(query.Title)) && 
                                           (string.IsNullOrEmpty(query.Genre) || c.Genre.Contains(query.Genre)));
        }
    }
}
