using zenflicks_backend.forums.Domain.Model.Commands;
using zenflicks_backend.forums.Interfaces.REST.Resources;

namespace zenflicks_backend.forums.Interfaces.REST.Transform;

public static class CreateForumCommandFromResourceAssembler
{
    public static CreateForumCommand ToCommandFromResource(CreateForumResource resource) =>
        new CreateForumCommand(resource.Title, resource.CommentBy, resource.Comment, resource.Image,
        resource.Score);
}