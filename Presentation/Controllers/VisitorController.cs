using Application.DTOs;
using Application.DTOs.Visitor_DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorService visitorService;
        public VisitorController(IVisitorService visitorService)
        {
            this.visitorService = visitorService;
        }

        [HttpPost]
        public async Task<IActionResult> AddVistor(AddVisitorRequestDto requestDto)
        {
            var response = await visitorService.AddVisitor(requestDto);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
