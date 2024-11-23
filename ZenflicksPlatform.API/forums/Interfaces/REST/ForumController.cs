using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using zenflicks_backend.forums.Domain.Model.Queries;
using zenflicks_backend.forums.Domain.Services;
using zenflicks_backend.forums.Interfaces.REST.Resources;
using zenflicks_backend.forums.Interfaces.REST.Transform;


namespace zenflicks_backend.forums.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class ForumController(
    IForumCommandService forumCommandService,
    IForumQueryService forumQueryService)
    : ControllerBase
{
    ///POST: /api/v1/forums
    /// <summary>
    /// Post a new forum comment.
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> CreateForum([FromBody] CreateForumResource resource)
    {
        var createForumCommand = CreateForumCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await forumCommandService.Handle(createForumCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetForumById), new { id = result.Id }, ForumResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetForumById(int id)
    {
        var getForumByIdQuery = new GetForumByIdQuery(id);
        var result = await forumQueryService.Handle(getForumByIdQuery);
        if (result is null) return NotFound();
        var resource = ForumResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAllForums()
    {
        var forums = await forumQueryService.Handle(new GetAllForumsQuery());
        var forumResources = forums.Select(ForumResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(forumResources);
    }
    
}