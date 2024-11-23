namespace zenflicks_backend.content.Domain.Model
{
    public class Content
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Duration { get; set; }
    }
}