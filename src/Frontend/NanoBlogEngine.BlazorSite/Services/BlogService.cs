using NanoBlogEngine.BlazorSite.Services.Contracts.BlogService.Requests;
using NanoBlogEngine.BlazorSite.Services.Contracts.BlogService.Responses;
using System.Net.Http.Json;

namespace NanoBlogEngine.BlazorSite.Services;

sealed class BlogService
{
    readonly HttpClient httpClient;
    readonly ILogger<BlogService> logger;

    public BlogService(HttpClient httpClient, ILogger<BlogService> logger)
    {
        this.httpClient = httpClient;
        this.logger = logger;
    }

    public async Task<UserSession> LoginAsync(Login login)
    {
        Console.WriteLine(httpClient.BaseAddress.ToString());
        try
        {
            var response = await httpClient.PostAsJsonAsync("User", login);
            var jwt = await response.Content.ReadFromJsonAsync<UserSession>();
            return jwt;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
