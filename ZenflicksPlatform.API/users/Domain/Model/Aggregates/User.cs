using zenflicks_backend.users.Domain.Model.Commands;

namespace zenflicks_backend.users.Domain.Model.Aggregates;

public class User
{
    public int Id { get; private set; }
    public string name { get; private set; }
    public string lastName { get; private set; }
    public string userName { get; private set; }
    public string birthDate { get; private set; }
    public string phone { get; private set; }
    public string email { get; private set; }
    public string password { get; private set; }
    public string membership { get; private set; }

    protected User()
    {
        this.name= string.Empty;
        this.lastName= string.Empty;
        this.userName= string.Empty;
        this.birthDate= string.Empty;
        this.phone= string.Empty;
        this.email= string.Empty;
        this.password= string.Empty;
        this.membership= string.Empty;
    }

    public User(CreateUserCommand command)
    {
        this.name= command.name;
        this.lastName= command.lastName;
        this.userName= command.userName;
        this.birthDate= command.birthDate;
        this.phone= command.phone;
        this.email= command.email;
        this.password= command.password;
        this.membership= command.membership;
    }
}