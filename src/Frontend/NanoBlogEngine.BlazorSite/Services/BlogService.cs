using NanoBlogEngine.BlazorSite.Services.Contracts.BlogService.Requests;
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

    public async Task<string> LoginAsync(Login login)
    {
        Console.WriteLine(httpClient.BaseAddress.ToString());
        try
        {
            var response = await httpClient.PostAsJsonAsync<Login>("User/Login", login);
            var jwt = await response.Content.ReadFromJsonAsync<string>();
        }
        catch (Exception ex)
        {

            throw;
        }
        

        //
        return "";
    }
}
