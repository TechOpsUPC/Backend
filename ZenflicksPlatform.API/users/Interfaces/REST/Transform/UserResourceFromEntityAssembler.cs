using zenflicks_backend.users.Domain.Model.Aggregates;
using zenflicks_backend.users.Interfaces.REST.Resources;

namespace zenflicks_backend.users.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity) =>
        new UserResource(entity.Id, entity.Name, entity.LastName, entity.UserName, entity.BirthDate,
            entity.Phone, entity.Email, entity.Password, entity.Membership);
}