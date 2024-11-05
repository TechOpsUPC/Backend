namespace zenflicks_backend.users.Interfaces.REST.Resources;

public record UserResource(int Id, string Name, string LastName, 
    string UserName, string BirthDate, string Phone, string Email, 
    string Password, string Membership);