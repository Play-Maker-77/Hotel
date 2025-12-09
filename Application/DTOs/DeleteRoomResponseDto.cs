using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DeleteRoomResponseDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public Room Room { get; set; }
    }
}
