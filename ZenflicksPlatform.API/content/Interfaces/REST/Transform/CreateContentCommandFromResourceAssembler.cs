using zenflicks_backend.content.Domain.Model.Commands;
using zenflicks_backend.content.Interfaces.REST.Resources;

namespace zenflicks_backend.content.Interfaces.REST.Transform
{
    public static class CreateContentCommandFromResourceAssembler
    {
        public static CreateContentCommand ToCommandFromResource(CreateContentResource resource)
        {
            if (resource == null)
                throw new ArgumentNullException(nameof(resource));

            return new CreateContentCommand(
                resource.Title,
                resource.Genre,
                resource.Description,
                resource.ReleaseDate,
                resource.Director,
                resource.Duration
            );
        }
    }
}