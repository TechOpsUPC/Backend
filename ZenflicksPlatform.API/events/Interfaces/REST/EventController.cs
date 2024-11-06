using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

using zenflicks_backend.events.Domain.Model.Queries;
using zenflicks_backend.events.Domain.Services;
using zenflicks_backend.events.Interfaces.REST.Resources;
using zenflicks_backend.events.Interfaces.REST.Transform;



namespace zenflicks_backend.events.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class EventController(
    IEventCommandService eventCommandService,
    IEventQueryService eventQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateEvent([FromBody] CreateEventResource resource)
    {
        var createEventCommand = CreateEventCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await eventCommandService.HandleCommand(createEventCommand);
        if(result is null) return BadRequest();
        return CreatedAtAction(nameof(GetEventById), new { id = result.Id }, EventResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetEventById(int id)
    {
        var getEventByIdQuery = new GetEventByIdQuery(id);
        var result = await eventQueryService.HandleQueryId(getEventByIdQuery);
        if(result is null ) return NotFound();
        var resource = EventResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
        
    }

    private async Task<ActionResult> GetEventByTittle(string tittle)
    {
        var getEventByTittleQuery = new GetEventByTittleQuery(tittle);
        var result = await eventQueryService.HandleQueryTittle(getEventByTittleQuery);
        if(result is null) return NotFound();
        var resource = EventResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    public async Task<ActionResult> GetEventFromQuery([FromQuery] string eventTittle = "")
    {
        return await GetEventByTittle(eventTittle);
    }
    
}