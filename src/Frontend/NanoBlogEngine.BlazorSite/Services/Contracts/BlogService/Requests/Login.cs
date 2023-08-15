namespace NanoBlogEngine.BlazorSite.Services.Contracts.BlogService.Requests;

public class Login
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}