public interface IAuthenticationService
{
    Task<AuthenticatedUserModel> Login(AuthenticationUserModel userToAuthenticate);

    Task Logout();
}