using BasicAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

[Route("api/error")]
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ExceptionController : ControllerBase
{
    [Route("error")]
    public IActionResult Error() => Problem();
}