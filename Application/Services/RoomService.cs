using Application.Converters;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IRoomService
    {
        Task<AddRoomResponseDto> AddRoom(AddRoomRequestDto requestDto);
        Task<DeleteRoomResponseDto> DeleteRoomAsync(int id);
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        //Task<RoomResponseDto?> GetRoomByIdAsync(int id);
        Task<DeleteRoomResponseDto> UpdateRoomAsync(UpdateRoomRequestDto dto);
    }

    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public async Task<AddRoomResponseDto> AddRoom(AddRoomRequestDto requestDto)
        {
            var statusCode = HttpStatusCode.BadRequest;
            if (!requestDto.IsValid()) return new AddRoomResponseDto() { Message = "Invalid data", StatusCode = statusCode };

            statusCode = HttpStatusCode.OK;
            var room = requestDto.ToRoomEntity();
            await roomRepository.AddRoomAsync(room);
            return new AddRoomResponseDto() { Message = "Success", StatusCode = statusCode };

        }

        public async Task<DeleteRoomResponseDto> DeleteRoomAsync(int id)
        {
            if (id <= 0) return new DeleteRoomResponseDto() { Message = "Invalid Room Id", StatusCode = HttpStatusCode.BadRequest };
            var room = await roomRepository.GetRoomByIdAsync(id);
            if (room == null) return new DeleteRoomResponseDto() { Message = "Room not found", StatusCode = HttpStatusCode.NotFound };
            if (room.IsAvailable) return new DeleteRoomResponseDto() { Message = "Cannot delete an available room", StatusCode = HttpStatusCode.BadRequest };
            await roomRepository.DeleteRoomAsync(room);
            return new DeleteRoomResponseDto() { Room=room, Message = "Success", StatusCode = HttpStatusCode.OK };
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await roomRepository.GetAllRoomsAsync();
        }

        public async Task<DeleteRoomResponseDto> UpdateRoomAsync(UpdateRoomRequestDto requestDto)
        {
            if (requestDto.Id <= 0) return new DeleteRoomResponseDto() { Message = "Invalid Room Id", StatusCode = HttpStatusCode.BadRequest };
            var room = await roomRepository.GetRoomByIdAsync(requestDto.Id);
            if (room == null) return new DeleteRoomResponseDto() { Message = "Room not found", StatusCode = HttpStatusCode.NotFound };
            if (room.IsAvailable) return new DeleteRoomResponseDto() { Message = "Cannot update an available room", StatusCode = HttpStatusCode.BadRequest };
            room.BedsCount = requestDto.BedsCount;
            room.RoomNumber = requestDto.RoomNumber;
            await roomRepository.UpdateRoomAsync(room);
            return new DeleteRoomResponseDto() { Room = room, Message = "Success", StatusCode = HttpStatusCode.OK };
        }
    }
}
