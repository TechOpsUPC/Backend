using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using zenflicks_backend.content.Domain.Model.Commands;
using zenflicks_backend.content.Domain.Model.Queries;
using zenflicks_backend.content.Domain.Services;
using zenflicks_backend.content.Interfaces.REST.Resources;
using zenflicks_backend.content.Interfaces.REST.Transform;

namespace zenflicks_backend.content.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ContentController : ControllerBase
    {
        private readonly IContentCommandService _contentCommandService;
        private readonly IContentQueryService _contentQueryService;

        public ContentController(IContentCommandService contentCommandService, IContentQueryService contentQueryService)
        {
            _contentCommandService = contentCommandService;
            _contentQueryService = contentQueryService;
        }


        // POST: api/v1/Content
        [HttpPost]
        public async Task<ActionResult> CreateContent([FromBody] CreateContentRequest request)
        {
            if (request?.Resource == null)
            {
                return BadRequest("The resource field is required.");
            }

            var createContentCommand = CreateContentCommandFromResourceAssembler.ToCommandFromResource(request.Resource);
            var result = await _contentCommandService.Handle(createContentCommand);
            if (result is null) return BadRequest();

            return CreatedAtAction(nameof(GetContentById), new { id = result.Id }, ContentResourceFromEntityAssembler.ToResourceFromEntity(result));
        }


        // GET: api/v1/Content/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetContentById(int id)
        {
            var getContentByIdQuery = new GetContentByIdQuery(id);
            var result = await _contentQueryService.Handle(getContentByIdQuery);
            if (result is null) return NotFound();
            var resource = ContentResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }

        // Método adicional para obtener contenido basado en consultas u otros criterios
        [HttpGet]
        public async Task<ActionResult> GetContentFromQuery([FromQuery] string title = "", [FromQuery] string genre = "")
        {
            var getContentByTitleAndGenreQuery = new GetContentByTitleAndGenreQuery(title, genre);
            var result = await _contentQueryService.Handle(getContentByTitleAndGenreQuery);
            if (result is null || !result.Any()) return NotFound();
            var resources = result.Select(ContentResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
    }
}
