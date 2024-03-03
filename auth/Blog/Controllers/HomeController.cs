using Blog.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

// Heath-Check
[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    [ApiKey]
    public IActionResult Get()
    {
        return Ok();
    }
}