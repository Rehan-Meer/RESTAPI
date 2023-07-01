using AutoMapper;
using BasicAPI.DBContext;
using BasicAPI.Services.GetService;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    public class BreakfastController : MainController
    {
        private readonly IBreakfastService breakfastService;
        private readonly IMapper mapper;
        private readonly BreakfastContext DbContext;

        public BreakfastController(IBreakfastService _breakfastService, IMapper _mapper, BreakfastContext _DbContext)
        {
            breakfastService = _breakfastService;
            mapper = _mapper;
            DbContext = _DbContext;
        }

        [HttpGet]
        [Route(RouteConstants.GetBreakfast)]
        public IActionResult GetBreakfast(int Id)
        {
            ErrorOr<Breakfast> response = breakfastService.GetBreakfast(Id, DbContext);
            return response.IsError ? GetProblem(response.Errors) : Ok(mapper.Map<BreakfastDto>(response.Value));
        }

        [HttpPost]
        [Route(RouteConstants.CreateBreakfast)]
        public IActionResult Createbreakfast(BreakfastDto _request)
        {
            Breakfast breakfast = mapper.Map<Breakfast>(_request);
            ErrorOr<Created> response = breakfastService.CreateBreakfast(breakfast, DbContext);
            return response.IsError ? GetProblem(response.Errors) : Ok();
        }

        [HttpPut]
        [Route(RouteConstants.UpdateBreakfast)]
        public IActionResult PutAll(BreakfastDto _request)
        {
            Breakfast breakfast = mapper.Map<Breakfast>(_request);
            ErrorOr<Updated> response = breakfastService.UpdateBreakfast(breakfast, DbContext);
            return Ok(mapper.Map<Breakfast>(response.Value));
        }

        [HttpDelete]
        [Route(RouteConstants.DeleteBreakfast)]
        public IActionResult DeleteBreakfast(int Id)
        {
            ErrorOr<Deleted> response = breakfastService.DeleteBreakfast(Id, DbContext);
            return Ok(response.Value);
        }
    }
}