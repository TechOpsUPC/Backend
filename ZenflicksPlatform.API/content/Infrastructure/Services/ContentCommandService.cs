namespace zenflicks_backend.content.Infrastructure.Services
{
    using zenflicks_backend.content.Domain.Model.Commands;
    using zenflicks_backend.content.Domain.Model;
    using zenflicks_backend.content.Domain.Repositories;
    using zenflicks_backend.content.Domain.Services;

    public class ContentCommandService : IContentCommandService
    {
        private readonly IContentRepository _contentRepository;

        public ContentCommandService(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task<Content> Handle(CreateContentCommand command)
        {
            // Aquí va la lógica de creación del contenido
            var content = new Content
            {
                Title = command.Title,
                Genre = command.Genre,
                Description = command.Description,
                ReleaseDate = command.ReleaseDate,
                Director = command.Director,
                Duration = command.Duration
            };

            // Guardar el contenido en el repositorio
            await _contentRepository.AddAsync(content);
            return content;
        }
    }
}