namespace zenflicks_backend.forums.Domain.Model.Commands;

public record CreateForumCommand(string Title, string CommentBy, string Comment, string Image, int Score);