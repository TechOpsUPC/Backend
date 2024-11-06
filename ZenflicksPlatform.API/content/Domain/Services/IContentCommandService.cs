namespace zenflicks_backend.content.Domain.Services
{
    using zenflicks_backend.content.Domain.Model.Commands;
    using zenflicks_backend.content.Domain.Model;

    public interface IContentCommandService
    {
        Task<Content> Handle(CreateContentCommand command);
    }
}