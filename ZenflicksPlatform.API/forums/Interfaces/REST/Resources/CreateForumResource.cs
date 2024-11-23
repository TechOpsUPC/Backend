namespace zenflicks_backend.forums.Interfaces.REST.Resources;

public record CreateForumResource(string Title, string CommentBy, string Comment, string Image, int Score);