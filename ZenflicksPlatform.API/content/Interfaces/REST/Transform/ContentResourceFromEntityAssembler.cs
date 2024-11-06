using zenflicks_backend.content.Domain.Model;
using zenflicks_backend.content.Interfaces.REST.Resources;

namespace zenflicks_backend.content.Interfaces.REST.Transform
{
    public static class ContentResourceFromEntityAssembler
    {
        public static ContentResource ToResourceFromEntity(Content content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            return new ContentResource
            {
                Id = content.Id,
                Title = content.Title,
                Genre = content.Genre,
                Description = content.Description,
                ReleaseDate = content.ReleaseDate,
                Director = content.Director,
                Duration = content.Duration
            };
        }
    }
}