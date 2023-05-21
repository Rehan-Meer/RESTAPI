using AutoMapper;
using BasicAPI.DTOs;
using BasicAPI.InternalModels;
using BasicAPI.RequestModels;
using BasicAPI.Services.GetService;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{

    public class HomeController : ApiController
    {
        private readonly IBreakfastService breakfastService;

        private readonly IMapper mapper;

        public HomeController(IBreakfastService BreakfastService, IMapper _mapper)
        {
            breakfastService = BreakfastService;
            mapper = _mapper;
        }


        [HttpGet]
        [Route(RouteConstants.GetBreakfast)]
        public IActionResult GetBreakfast(int ID)
        {
            ErrorOr<BreakfastModel> response = breakfastService.GetBreakfast(ID);

            if (response.IsError)
                return GetProblem(response.Errors);
            else
            {
                BreakfastResponseDto breakfastResponseDto = mapper.Map<BreakfastResponseDto>(response.Value);
                return Ok(breakfastResponseDto);
            }
        }


        [HttpPost]
        [Route(RouteConstants.CreateBreakfast)]
        public IActionResult Createbreakfast(BreakfastRequest _request)
        {
            BreakfastModel internalModelObject = new(_request.Id, _request.Name);
            ErrorOr<Created> response = breakfastService.CreateBreakfast(internalModelObject);

            if (response.IsError)
                return GetProblem(response.Errors);
            else
                return Ok();
        }


        [HttpPut]
        [Route(RouteConstants.UpdateBreakfast)]
        public IActionResult PutAll(BreakfastRequest _request)
        {
            BreakfastModel internalModelObject = new(_request.Id, _request.Name);
            ErrorOr<Updated> response = breakfastService.UpdateBreakfast(internalModelObject);
            BreakfastResponseDto breakfastResponseDto = mapper.Map<BreakfastResponseDto>(response.Value);
            return Ok(breakfastResponseDto);
        }


        [HttpDelete]
        [Route(RouteConstants.DeleteBreakfast)]
        public IActionResult DeleteBreakfast(int ID)
        {
            breakfastService.DeleteBreakfast(ID);
            return Ok();
        }
    }
}
