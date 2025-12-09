using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService roomService;
        public RoomsController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(AddRoomRequestDto requestDto)
        {
            var response = await roomService.AddRoom(requestDto);
            return StatusCode((int)response.StatusCode ,response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var response = await roomService.DeleteRoomAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoom(UpdateRoomRequestDto requestDto)
        {
            var response = await roomService.UpdateRoomAsync(requestDto);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var response = await roomService.GetAllRoomsAsync();
            return Ok(response);
        }
    }
}
