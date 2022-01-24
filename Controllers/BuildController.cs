
using Microsoft.AspNetCore.Mvc;

namespace Ards.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BuildController : Controller
{
    [HttpPost("requeue")]
    public IActionResult Requeue([FromBody]string buildNumber)
    {
        return Ok("hello" + buildNumber);
    }
}