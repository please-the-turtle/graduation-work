using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using BuisnessLogicLayer;

namespace ControlOfWork.Infrastructure;

public class TokenAuthenticationStateProvider : AuthenticationStateProvider
{
    private const string AuthenticationType = "Token";

    public TokenAuthenticationStateProvider(ProtectedLocalStorage localStorage, UserService userService)
    {
        LocalStorage = localStorage;
        UserService = userService;
    }

    public ProtectedLocalStorage LocalStorage { get; }
    public UserService UserService { get; }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var storageResult = await LocalStorage.GetAsync<SecurityToken>(nameof(SecurityToken));

        if (!storageResult.Success)
        {
            return CreateAnonymousAuthenticationState();
        }

        SecurityToken token = storageResult.Value!;

        if (string.IsNullOrWhiteSpace(token.AccessToken) || DateTime.UtcNow > token.ExpiredAt)
        {
            return CreateAnonymousAuthenticationState();
        }

        if (TryToAuthenticate(token.Login, token.AccessToken))
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, token.Login)
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, AuthenticationType);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            return new AuthenticationState(principal);
        }

        return CreateAnonymousAuthenticationState();
    }

    private bool TryToAuthenticate(string login, string accessToken)
    {
        try
        {
            return UserService.Authenticate(login, accessToken);
        }
        catch
        {
            return false;
        }
    }

    private AuthenticationState CreateAnonymousAuthenticationState()
    {
        ClaimsIdentity identity = new ClaimsIdentity();
        ClaimsPrincipal principal = new ClaimsPrincipal(identity);

        return new AuthenticationState(principal);
    }
}