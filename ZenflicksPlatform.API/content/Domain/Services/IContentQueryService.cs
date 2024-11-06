namespace zenflicks_backend.content.Domain.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using zenflicks_backend.content.Domain.Model;
    using zenflicks_backend.content.Domain.Model.Queries;

    public interface IContentQueryService
    {
        Task<Content> Handle(GetContentByIdQuery query);
        Task<IEnumerable<Content>> Handle(GetContentByTitleAndGenreQuery query);
    }
}