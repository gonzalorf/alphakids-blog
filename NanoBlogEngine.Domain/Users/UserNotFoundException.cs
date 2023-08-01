namespace NanoBlogEngine.Domain.Users;

public sealed class UserNotFoundException : Exception
{
    public UserNotFoundException(string email) : base($"User with email {email} not found.")
    {
    }
}
