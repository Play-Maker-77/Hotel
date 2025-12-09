using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateRoomRequestDto
    {
        public int Id { get; set; }
        public int BedsCount { get; set; }
        public int RoomNumber { get; set; }

        public bool IsValid()
        {
            if (Id <= 0 || BedsCount <= 0 || RoomNumber <= 0) return false;
            return true;
        }
    }
}
