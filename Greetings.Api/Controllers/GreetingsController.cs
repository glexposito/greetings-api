using Microsoft.AspNetCore.Mvc;

namespace Greetings.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GreetingsController : ControllerBase
{
    [HttpGet("hello")]
    public ActionResult<string> Hello() => "Hello!";

    [HttpGet("bye")]
    public ActionResult<string> Bye() => "Bye!";
}