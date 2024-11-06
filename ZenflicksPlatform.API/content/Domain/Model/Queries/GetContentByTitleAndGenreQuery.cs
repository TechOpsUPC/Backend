namespace zenflicks_backend.content.Domain.Model.Queries
{
    public class GetContentByTitleAndGenreQuery
    {
        public string Title { get; }
        public string Genre { get; }

        public GetContentByTitleAndGenreQuery(string title, string genre)
        {
            Title = title;
            Genre = genre;
        }
    }
}