using BuberDinner.Api.Common.Mappings;
using BuberDinner.Contracts.Menu;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("hosts/{hostId}/menus")]
public class MenusController(ISender mediator) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        [FromBody]CreateMenuRequest request,
        string hostId)
    {
        var createMenuResult = await mediator.Send(request.ToCommand(hostId));
        return createMenuResult.Match(
            result => Ok(result.ToResponse()),
            errors => Problem(errors));
    }
}