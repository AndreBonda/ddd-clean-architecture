using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService, IConfiguration configuration) : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        AuthenticationResponse response = new(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token);
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = authenticationService.Login(request.Email, request.Password);
        AuthenticationResponse response = new(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token);
        return Ok(response);
    }
}