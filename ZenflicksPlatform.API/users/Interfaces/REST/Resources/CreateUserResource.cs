namespace zenflicks_backend.users.Interfaces.REST.Resources;

public record CreateUserResource(string Name, string LastName, 
    string UserName, string BirthDate, string Phone, string Email, 
    string Password, string Membership);