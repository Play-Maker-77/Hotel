using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Visitor_DTOs
{
    public class AddVisitorRequestDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int RoomId { get; set; }

        public bool IsValid()
        {
            if (RoomId >0 && Name != null && Phone != null)
            {
                return true;
            }

            return false;
        }
    }
}
