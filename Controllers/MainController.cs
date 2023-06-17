using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    [ApiController]
    [Route(RouteConstants.MainController)]
    public class MainController : ControllerBase
    {
        [Route(RouteConstants.GlobalExceptionHandler)]
        protected IActionResult GetProblem(List<Error> errors)
        {
            Error firstError = errors.FirstOrDefault();
            int statusCode = firstError.Type switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, detail: firstError.Description);
        }
    }
}
