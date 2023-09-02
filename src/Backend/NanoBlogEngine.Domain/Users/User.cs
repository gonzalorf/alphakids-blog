using NanoBlogEngine.Domain.SeedWork;

namespace NanoBlogEngine.Domain.Users;

public class User : Entity<UserId>, IAggregateRoot
{
    private User() : base() { }

    public User(UserId id, string name, string email, string password) : base(id)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public UserRole Role { get; private set; } = UserRole.BlogReaderRole;

}
