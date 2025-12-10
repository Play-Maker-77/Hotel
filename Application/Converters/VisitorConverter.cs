using Application.DTOs.Visitor_DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters
{
    public class VisitorConverter
    {
        public static Visitor ToVisitorEntity(AddVisitorRequestDto visitor)
        {
            return new Visitor()
            {
                Name = visitor.Name,
                Phone = visitor.Phone,
                RoomId = visitor.RoomId,
            };
        }
    }
}
