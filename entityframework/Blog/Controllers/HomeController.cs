using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

// Heath-Check
[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get()
    {
        return Ok();
    }
}