using BuberDinner.Domain.User;

namespace BuberDinner.Application.Authentication.Common;

public sealed record AuthenticationResult(User User, string Token);