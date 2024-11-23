using zenflicks_backend.forums.Domain.Model.Commands;

namespace zenflicks_backend.forums.Domain.Model.Aggregates;

public class Forum
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string CommentBy { get; private set; }
    public string Comment { get; private set; }
    public string Image { get; private set; }
    public int Score { get; private set; }
    
    protected Forum()
    {
        this.Title = string.Empty;
        this.CommentBy = string.Empty;
        this.Comment = string.Empty;
        this.Image = string.Empty;
        this.Score = 0;
    }
    
    public Forum(CreateForumCommand command)
    {
        this.Title = command.Title;
        this.CommentBy = command.CommentBy;
        this.Comment = command.Comment;
        this.Image = command.Image;
        this.Score = 0;
    }
}