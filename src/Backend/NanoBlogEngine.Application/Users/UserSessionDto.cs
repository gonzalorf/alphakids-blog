namespace NanoBlogEngine.Application.Users;

public record UserSessionDto(string Name, string LastName, string Email, string Role, string Token);
