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

    //public async Task<string> GetCategoriesAsync()
    //{

    //}
}
