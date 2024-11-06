namespace zenflicks_backend.content.Domain.Model.Queries
{
    public class GetContentByIdQuery
    {
        public int Id { get; private set; }

        public GetContentByIdQuery(int id)
        {
            Id = id;
        }
    }
}