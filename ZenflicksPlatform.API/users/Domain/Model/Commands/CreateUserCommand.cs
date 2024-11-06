namespace zenflicks_backend.users.Domain.Model.Commands;

public record CreateUserCommand(string name, string lastName, string userName, 
    string birthDate, string phone, string email, string password, string membership);