using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NanoBlogEngine.BlazorSite.Authorization;
using NanoBlogEngine.BlazorSite.Services;

namespace NanoBlogEngine.BlazorSite.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddHttpClient<BlogService>((serviceProvider, httpClient) =>
        {
            // Set the base address of the named client.
            httpClient.BaseAddress = new Uri("https://localhost:7237/api/");

            // Add a user-agent default request header.
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
        });

        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddScoped<AuthenticationStateProvider, NanoBlogAuthenticationStateProvider>();

        await builder.Build().RunAsync();
    }
}