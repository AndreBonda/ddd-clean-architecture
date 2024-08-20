using System.Net;
using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService, IConfiguration configuration)
    : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var registerResult =
            authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return registerResult.MatchFirst(
            result => Ok(MapAuthResult(result)),
            error => Problem(statusCode: (int)HttpStatusCode.BadRequest, title: error.Description));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var loginResult = authenticationService.Login(request.Email, request.Password);

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