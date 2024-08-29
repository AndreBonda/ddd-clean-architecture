using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler(
    IUserRepository userRepository,
    IJwtTokenGenerator tokenGenerator)
    : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        User? user = userRepository.GetUserByEmail(query.Email);
        if (user is null || user.Password != query.Password)
            return Errors.Authentication.LoginFail;

        string token = tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}