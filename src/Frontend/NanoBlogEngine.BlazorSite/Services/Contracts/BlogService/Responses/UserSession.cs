namespace NanoBlogEngine.BlazorSite.Services.Contracts.BlogService.Responses;

public record UserSession(string Name, string LastName, string Email, string Role, string Token);
