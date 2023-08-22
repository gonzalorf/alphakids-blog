using NanoBlogEngine.Domain.SeedWork;

namespace NanoBlogEngine.Domain.Users;

public class User : Entity, IAggregateRoot
{
    public User(UserId id, string name, string email, string password)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
    }

    public UserId Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public UserRole Role { get; private set; }

}
