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
        public TaskController(IUserService _userService, ITaskService _taskService, IMapper _mapper, ClientDBContext _DbContext)
            : base(_userService, _taskService, _mapper, _DbContext) { }

        [HttpGet]
        [Route(RouteConstants.GetTasks)]
        public IActionResult GetTasks(int ID)
        {
            ErrorOr<List<Task>> response = taskService.GetTasks(ID, dbContext);
            return response.IsError ? GetProblem(response.Errors) : Ok(mapper.Map<List<TaskDto>>(response.Value));
        }

        [HttpPost]
        [Route(RouteConstants.CreateTask)]
        public IActionResult CreateTask(TaskDto task)
        {
            var taskObject = mapper.Map<Task>(task);
            ErrorOr<Created> response = taskService.CreateTask(taskObject, dbContext);
            return response.IsError ? GetProblem(response.Errors) : Ok();
        }

        [HttpPut]
        [Route(RouteConstants.UpdateTask)]
        public IActionResult UpdateTask(TaskDto _request)
        {
            Task toBeUpdated = mapper.Map<Task>(_request);
            ErrorOr<Updated> response = taskService.UpdateTask(toBeUpdated, dbContext);
            return Ok(mapper.Map<Task>(response.Value));
        }

        [HttpDelete]
        [Route(RouteConstants.DeleteTask)]
        public IActionResult DeleteTask(int Id)
        {
            ErrorOr<Deleted> response = taskService.DeleteTask(Id, dbContext);
            return Ok(response.Value);
        }
    }
}