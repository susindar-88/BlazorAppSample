using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using BlazorApp.Authentication;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

public class AuthenticationService :IAuthenticationService
{
    private readonly HttpClient _client;
    private ILocalStorageService _localStorage;

    private AuthenticationStateProvider _authStateProvider;

    public AuthenticationService(HttpClient client,
                                 AuthenticationStateProvider authStateProvider,
                                 ILocalStorageService localStorage)
    {
        _client = client;
        _authStateProvider = authStateProvider;
        _localStorage = localStorage;
    }

    public async Task<AuthenticatedUserModel> Login(AuthenticationUserModel userToAuthenticate)
    {

        var authResult = await _client.PostAsJsonAsync<AuthenticationUserModel>("https://localhost:7294/token", userToAuthenticate);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode == false)
        {
            return null;
        }
        var result = JsonSerializer.Deserialize<AuthenticatedUserModel>(
            authContent,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        await _localStorage.SetItemAsync("authToken", result.Access_Token);
        ((AuthStateProvider)_authStateProvider).NotifyAuthentication(result.Access_Token);

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Access_Token);

        return result;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((AuthStateProvider)_authStateProvider).NotifyLogout();
    }
}