using AutoMapper;
using BasicAPI.DBContext;
using BasicAPI.Services.GetService;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    [ApiController]
    [Route(RouteConstants.MainController)]
    public class MainController : ControllerBase
    {
        public readonly IUserService userService;
        public readonly ITaskService taskService;
        public readonly IMapper mapper;
        public readonly ClientDBContext dbContext;

        public MainController(IUserService _userService, ITaskService _taskService, IMapper _mapper, ClientDBContext _DbContext)
        {
            userService = _userService;
            taskService = _taskService;
            mapper = _mapper;
            dbContext = _DbContext;
        }

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