using zenflicks_backend.users.Domain.Model.Commands;

namespace zenflicks_backend.users.Domain.Model.Aggregates;

public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string UserName { get; private set; }
    public string BirthDate { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Membership { get; private set; }

    protected User()
    {
        this.Name= string.Empty;
        this.LastName= string.Empty;
        this.UserName= string.Empty;
        this.BirthDate= string.Empty;
        this.Phone= string.Empty;
        this.Email= string.Empty;
        this.Password= string.Empty;
        this.Membership= string.Empty;
    }

    public User(CreateUserCommand command)
    {
        this.Name= command.name;
        this.LastName= command.lastName;
        this.UserName= command.userName;
        this.BirthDate= command.birthDate;
        this.Phone= command.phone;
        this.Email= command.email;
        this.Password= command.password;
        this.Membership= command.membership;
    }
}