using AutoMapper;
using BasicAPI.DBContext;
using BasicAPI.DTOs;
using BasicAPI.Services.GetService;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    //[Authorize]
    public class UserController : MainController
    {
        public UserController(IUserService _userService,ITaskService _taskService, IMapper _mapper, ClientDBContext _DbContext) 
            : base(_userService, _taskService ,_mapper, _DbContext){}

        [HttpGet]
        [Route(RouteConstants.GetUser)]
        public IActionResult GetUser(int Id)
        {
            ErrorOr<User> response = userService.GetUser(Id, dbContext);
            return response.IsError ? GetProblem(response.Errors) : Ok(mapper.Map<UserDto>(response.Value));
        }

        [HttpGet]
        [Route(RouteConstants.GetAllUsers)]
        public IActionResult GetAllUsers()
        {
            ErrorOr<List<User>> response = userService.GetAllUsers(dbContext);
            return response.IsError ? GetProblem(response.Errors) : Ok(mapper.Map<List<UserDto>>(response.Value));
        }

        [HttpPost]
        [Route(RouteConstants.CreateUser)]
        public IActionResult CreateUser(UserDto _request)
        {
            User user = mapper.Map<User>(_request);
            ErrorOr<Created> response = userService.CreateUser(user, dbContext);
            return response.IsError ? GetProblem(response.Errors) : Ok();
        }

        [HttpPut]
        [Route(RouteConstants.UpdateUser)]
        public IActionResult UpdateUser(UserDto _request)
        {
            User breakfast = mapper.Map<User>(_request);
            ErrorOr<Updated> response = userService.UpdateUser(breakfast, dbContext);
            return Ok(mapper.Map<User>(response.Value));
        }

        [HttpDelete]
        [Route(RouteConstants.DeleteUser)]
        public IActionResult DeleteUser(int Id)
        {
            ErrorOr<Deleted> response = userService.DeleteUser(Id, dbContext);
            return Ok(response.Value);
        }
    }
}