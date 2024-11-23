namespace zenflicks_backend.forums.Interfaces.REST.Resources;

public record ForumResource(int Id, string Title, string CommentBy, 
    string Comment, string Image, int Score);