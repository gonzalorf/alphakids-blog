using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NanoBlogEngine.BlazorSite.Services;

namespace NanoBlogEngine.BlazorSite.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<NanoBlogEngine.BlazorSite.App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddHttpClient<BlogService>((serviceProvider, httpClient) =>
        {
            // Set the base address of the named client.
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

            // Add a user-agent default request header.
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
        });

        await builder.Build().RunAsync();
    }
}