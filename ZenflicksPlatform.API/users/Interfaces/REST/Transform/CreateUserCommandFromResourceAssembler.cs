using zenflicks_backend.users.Domain.Model.Commands;
using zenflicks_backend.users.Interfaces.REST.Resources;

namespace zenflicks_backend.users.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource) =>
        new CreateUserCommand(resource.Name, resource.LastName, resource.UserName, resource.BirthDate, resource.Phone, resource.Email,
            resource.Password, resource.Membership);
}