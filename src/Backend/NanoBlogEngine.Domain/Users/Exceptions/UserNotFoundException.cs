namespace NanoBlogEngine.Domain.Users.Exceptions;

public sealed class UserNotFoundException : ApplicationException
{
    public UserNotFoundException(string email) : base($"User with email {email} not found.")
    {
    }
}
