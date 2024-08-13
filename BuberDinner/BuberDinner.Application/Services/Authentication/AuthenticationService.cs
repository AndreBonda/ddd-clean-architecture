namespace BuberDinner.Application.Services.Authentication;

public sealed class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        return new(Guid.NewGuid(), firstName, lastName, email, "a-token");
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new(Guid.NewGuid(), "firstName", "lastName", email, "a-token");
    }
}