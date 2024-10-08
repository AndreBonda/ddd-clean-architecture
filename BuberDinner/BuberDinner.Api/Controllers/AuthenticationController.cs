using BuberDinner.Api.Common.Mappings;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
[AllowAnonymous]
public class AuthenticationController(ISender mediator) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var registerResult = await mediator.Send(request.ToCommand());

        return registerResult.Match(
            result => Ok(result.ToResponse()),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        LoginQuery query = new(request.Email, request.Password);
        var loginResult = await mediator.Send(query);

        return loginResult.Match(
            result => Ok(result.ToResponse()),
            error => Problem(error));
    }
}