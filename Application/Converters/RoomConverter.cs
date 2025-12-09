using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters
{
    public static class RoomConverter
    {
        public static Room ToRoomEntity(this AddRoomRequestDto room)
        {
            return new Room()
            {
                BedsCount = room.BedsCount,
                RoomNumber = room.RoomNumber,
            };
        }
    }
}
