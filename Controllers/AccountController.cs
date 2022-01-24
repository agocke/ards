
using Microsoft.AspNetCore.Mvc;

namespace Ards.Controllers;

[ApiController]
public class AccountController : Controller
{
    [HttpGet("/api/oath-callback")]
    public IActionResult AzdoOathCallback()
    {
        return Ok("hello azdo");
    }
}