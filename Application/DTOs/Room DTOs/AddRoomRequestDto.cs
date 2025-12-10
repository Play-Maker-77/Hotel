using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AddRoomRequestDto
    {
        public int BedsCount { get; set; }
        public int RoomNumber { get; set; }

        public bool IsValid()
        {
            if (BedsCount <= 0 ||  RoomNumber <= 0) return false;
            return true;
        }
    }
}
