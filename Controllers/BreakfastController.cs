using AutoMapper;
using BasicAPI.Services.GetService;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    public class BreakfastController : MainController
    {
        private readonly IBreakfastService breakfastService;                                       // Dependency Injection

        private readonly IMapper mapper;                                                           // AutoMapper for translation between DTOs and InternalModels

        public BreakfastController(IBreakfastService _breakfastService, IMapper _mapper)
        {
            breakfastService = _breakfastService;
            mapper = _mapper;
        }


        [HttpGet]
        [Route(RouteConstants.GetBreakfast)]
        public IActionResult GetBreakfast(int Id)
        {
            ErrorOr<Breakfast> response = breakfastService.GetBreakfast(Id);

            if (response.IsError)
                return GetProblem(response.Errors);
            else
            {
                BreakfastDto breakfast = mapper.Map<BreakfastDto>(response.Value);
                return Ok(breakfast);
            }
        }


        [HttpPost]
        [Route(RouteConstants.CreateBreakfast)]
        public IActionResult Createbreakfast(BreakfastDto _request)
        {
            Breakfast breakfast = mapper.Map<Breakfast>(_request);
            ErrorOr<Created> response = breakfastService.CreateBreakfast(breakfast);

            if (response.IsError)
                return GetProblem(response.Errors);
            else
                return Ok();
        }


        [HttpPut]
        [Route(RouteConstants.UpdateBreakfast)]
        public IActionResult PutAll(BreakfastDto _request)
        {
            Breakfast breakfast = mapper.Map<Breakfast>(_request);
            ErrorOr<Updated> response = breakfastService.UpdateBreakfast(breakfast);
            Breakfast breakfastResponseDto = mapper.Map<Breakfast>(response.Value);
            return Ok(breakfastResponseDto);
        }


        [HttpDelete]
        [Route(RouteConstants.DeleteBreakfast)]
        public IActionResult DeleteBreakfast(int Id)
        {
            breakfastService.DeleteBreakfast(Id);
            return Ok();
        }
    }
}
