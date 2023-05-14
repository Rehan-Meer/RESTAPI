using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace BasicAPI.Controllers
{
    public class ExceptionController : ControllerBase
    {
        [HttpOptions]
        [Route("/error")]
        public IActionResult GetException()
        {
            return Problem();
        }
    }
}
