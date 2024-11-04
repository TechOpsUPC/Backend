using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using zenflicks_backend.users.Domain.Model.Queries;
using zenflicks_backend.users.Domain.Services;
using zenflicks_backend.users.Interfaces.REST.Resources;
using zenflicks_backend.users.Interfaces.REST.Transform;

namespace zenflicks_backend.users.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UserController(
    IUserCommandService userCommandService,
    IUserQueryService userQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserResource resource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await userCommandService.Handle(createUserCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetUserById), new { id = result.Id }, UserResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var result = await userQueryService.Handle(getUserByIdQuery);
        if (result is null) return NotFound();
        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    public async Task<ActionResult> GetUserByUsernameAndPassword(string username, string password)
    {
        var getUserByUsernameAndPasswordQuery = new GetUserByUsernameAndPasswordQuery(username, password);
        var result = await userQueryService.Handle(getUserByUsernameAndPasswordQuery);
        if (result is null) return NotFound();
        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetUserFromQuery([FromQuery] string userName = "",[FromQuery] string password = "")
    {
        return await GetUserByUsernameAndPassword(userName, password);
    }
    
    
}