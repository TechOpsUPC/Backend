namespace zenflicks_backend.users.Domain.Model.Queries;

public record GetUserByUsernameAndPasswordQuery(string userName, string password);