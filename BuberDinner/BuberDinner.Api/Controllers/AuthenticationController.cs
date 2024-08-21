using System.Net;
using BuberDinner.Application.Authentication.Commands.RegisterUser;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(ISender mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        RegisterUserCommand command = new(request.FirstName, request.LastName, request.Email, request.Password);
        var registerResult = await mediator.Send(command);

        return registerResult.MatchFirst(
            result => Ok(MapAuthResult(result)),
            error => Problem(statusCode: (int)HttpStatusCode.BadRequest, title: error.Description));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        LoginQuery query = new(request.Email, request.Password);
        var loginResult = await mediator.Send(query);

        return loginResult.MatchFirst(
            result => Ok(MapAuthResult(result)),
            error => Problem(statusCode: (int)HttpStatusCode.BadRequest, title: error.Description));
    }

    private AuthenticationResponse MapAuthResult(AuthenticationResult resultData)
    {
        return new(
            resultData.User.Id,
            resultData.User.FirstName,
            resultData.User.LastName,
            resultData.User.Email,
            resultData.Token);
    }
}