using ErrorOr;

namespace BuberDinner.Domain.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error LoginFail =>
            Error.Failure(code: "User.LoginFail", description: "Invalid username or password");
    }
}