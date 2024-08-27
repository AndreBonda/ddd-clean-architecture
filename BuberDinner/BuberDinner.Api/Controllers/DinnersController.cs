using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DinnersController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> ListDinners()
    {
        return Ok();
    }
}