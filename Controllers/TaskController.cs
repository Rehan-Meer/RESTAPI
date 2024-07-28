using AutoMapper;
using BasicAPI.DBContext;
using BasicAPI.DTOs;
using BasicAPI.Services.GetService;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    public class TaskController : MainController
    {
        public TaskController(IUserService _userService, ITaskService _taskService ,IMapper _mapper, ClientDBContext _DbContext) 
            : base(_userService, _taskService, _mapper, _DbContext){}


        [HttpGet]
        [Route(RouteConstants.GetTask)]
        public IActionResult GetTask(int ID)
        {
            ErrorOr<Task> response = taskService.GetTask(ID, dbContext);
            return response.IsError ? GetProblem(response.Errors) : Ok(mapper.Map<TaskDto>(response.Value));

        }
    }
}
