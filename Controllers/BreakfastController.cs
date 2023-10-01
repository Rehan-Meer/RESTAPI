using AutoMapper;
using BasicAPI.DBContext;
using BasicAPI.Services.GetService;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    [Authorize]
    public class BreakfastController : MainController
    {
        private readonly IBreakfastService breakfastService;
        private readonly IMapper mapper;
        private readonly BreakfastContext dbContext;

        public BreakfastController(IBreakfastService _breakfastService, IMapper _mapper, BreakfastContext _DbContext)
        {
            breakfastService = _breakfastService;
            mapper = _mapper;
            dbContext = _DbContext;
        }

        [HttpGet]
        [Route(RouteConstants.GetBreakfast)]
        public IActionResult GetBreakfast(int Id)
        {
            ErrorOr<Breakfast> response = breakfastService.GetBreakfast(Id, dbContext);
            return response.IsError ? GetProblem(response.Errors) : Ok(mapper.Map<BreakfastDto>(response.Value));
        }

        [HttpPost]
        [Route(RouteConstants.CreateBreakfast)]
        public IActionResult Createbreakfast(BreakfastDto _request)
        {
            Breakfast breakfast = mapper.Map<Breakfast>(_request);
            ErrorOr<Created> response = breakfastService.CreateBreakfast(breakfast, dbContext);
            return response.IsError ? GetProblem(response.Errors) : Ok();
        }

        [HttpPut]
        [Route(RouteConstants.UpdateBreakfast)]
        public IActionResult UpdateBreakfast(BreakfastDto _request)
        {
            Breakfast breakfast = mapper.Map<Breakfast>(_request);
            ErrorOr<Updated> response = breakfastService.UpdateBreakfast(breakfast, dbContext);
            return Ok(mapper.Map<Breakfast>(response.Value));
        }

        [HttpDelete]
        [Route(RouteConstants.DeleteBreakfast)]
        public IActionResult DeleteBreakfast(int Id)
        {
            ErrorOr<Deleted> response = breakfastService.DeleteBreakfast(Id, dbContext);
            return Ok(response.Value);
        }
    }
}