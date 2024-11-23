using zenflicks_backend.forums.Domain.Model.Aggregates;
using zenflicks_backend.forums.Interfaces.REST.Resources;

namespace zenflicks_backend.forums.Interfaces.REST.Transform;

public static class ForumResourceFromEntityAssembler
{
    public static ForumResource ToResourceFromEntity(Forum entity) =>
        new ForumResource(entity.Id, entity.Title, entity.CommentBy, entity.Comment,
            entity.Image, entity.Score);
}