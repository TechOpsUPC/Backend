namespace zenflicks_backend.content.Domain.Model.Commands
{
    public class CreateContentCommand
    {
        public string Title { get; private set; }
        public string Genre { get; private set; }
        public string Description { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string Director { get; private set; }
        public TimeSpan Duration { get; private set; }

        public CreateContentCommand(string title, string genre, string description, DateTime releaseDate, string director, TimeSpan duration)
        {
            Title = title;
            Genre = genre;
            Description = description;
            ReleaseDate = releaseDate;
            Director = director;
            Duration = duration;
        }
    }
}