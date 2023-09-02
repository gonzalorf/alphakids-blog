using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using NanoBlogEngine.BlazorSite.Extensions;
using NanoBlogEngine.BlazorSite.Services.Contracts.BlogService.Responses;
using System.Security.Claims;

namespace NanoBlogEngine.BlazorSite.Authorization;

public class NanoBlogAuthenticationStateProvider : AuthenticationStateProvider
{
    ClaimsPrincipal anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());

    ILocalStorageService localStorageService;

    public NanoBlogAuthenticationStateProvider(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var userSession = await localStorageService.GetItem<UserSession>("user-session");
            if (userSession == null) { return await Task.FromResult(new AuthenticationState(anonymousUser)); }

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.Name),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }
                , "jwt"
                ));

            return new AuthenticationState(claimsPrincipal);
        }
        catch
        {
            return await Task.FromResult(new AuthenticationState(anonymousUser));
        }        
    }

    public async Task UpdateState(UserSession userSession)
    {
        ClaimsPrincipal claimsPrincipal;

        if(userSession != null) {
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.Name),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }
                , "jwt"
                ));

            // TODO: add expiration
            await localStorageService.StoreItem("user-session", claimsPrincipal);
        }
        else
        {
            claimsPrincipal = anonymousUser;
            await localStorageService.RemoveItemAsync("user-session");
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    public async Task<string> GetToken()
    {
        var token = string.Empty;

        try
        {
            // TODO: check expiration
            var userSession = await localStorageService.GetItemAsync<UserSession>("user-session");
            token = userSession.Token;
        }
        catch { }

        return token;
    }
}
