using BasicAPI.DTOs;
using BasicAPI.InternalModels;
using BasicAPI.RequestModels;
using BasicAPI.Services.GetService;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace BasicAPI.Controllers
{
    [ApiController]
    [Route(RouteConstants.Home)]
    public class HomeController : ApiController
    {
        private readonly IBreakfastService breakfastService;

        public HomeController(IBreakfastService _breakfastService) => breakfastService = _breakfastService;


        [HttpGet]
        [Route(RouteConstants.GetBreakfast)]
        public ActionResult GetBreakfast(int id)
        {
            // Get the data according to request in your internal model
            // Translate the internal model back to its equivalent Dto
            // Return that Dto
            var response = breakfastService.GetBreakfast(id);
            BreakfastResponseDto breakfastResponseDto = new BreakfastResponseDto { Id = response.Id, Name = response.Name };
            return Ok(breakfastResponseDto);
        }

        [HttpPost]
        [Route(RouteConstants.SaveBreakfast)]
        public ActionResult Savebreakfast(BreakfastRequest _request)
        {
            // Get the data according to request in your internal model
            // Save internal model in the database.
            // Translate the Internal model back to its equivalent Dto
            // Return that Dto
            BreakfastModel internalModelObject = new(_request.Id, _request.Name);
            breakfastService.CreateBreakfast(internalModelObject);
            BreakfastResponseDto breakfastResponseDto = new BreakfastResponseDto { Id = internalModelObject.Id, Name = internalModelObject.Name };
            return Ok(breakfastResponseDto);
        }


        [HttpPut]
        [Route(RouteConstants.UpdateBreakfast)]
        public IActionResult PutAll(BreakfastRequest _request)
        {
            BreakfastModel internalModelObject = new(_request.Id, _request.Name);
            breakfastService.UpdateBreakfast(internalModelObject);
            BreakfastResponseDto breakfastResponseDto = new BreakfastResponseDto { Id = internalModelObject.Id, Name = internalModelObject.Name };
            return Ok(breakfastResponseDto);
        }


        [HttpDelete]
        [Route(RouteConstants.DeleteBreakfast)]
        public IActionResult DeleteBreakfast(int id)
        {
            breakfastService.DeleteBreakfast(id);
            return Ok();
        }
    }
}
