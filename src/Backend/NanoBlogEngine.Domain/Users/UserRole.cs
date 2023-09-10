namespace NanoBlogEngine.Domain.Users;

public record UserRole()
{
    public string? Name { get; private set; }
    public static UserRole AdministratorRole => new() { Name = "Administrator" };
    public static UserRole BlogReaderRole => new() { Name = "BlogReader" };
    public static UserRole CreateFromName(string? name)
    {
        return new UserRole() { Name = name }; // TODO: validate name
    }
}