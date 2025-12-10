using Application.Converters;
using Application.DTOs.Visitor_DTOs;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IVisitorService
    {
        Task<AddVisitorResponseDto> AddVisitor(AddVisitorRequestDto addVisitorRequestDto);
    }

    public class VisitorServices : IVisitorService
    {
        private readonly IVisitorRepository _visitorRepository;

        public VisitorServices(IVisitorRepository visitorRepository)
        {
            this._visitorRepository = visitorRepository;
        }

        public async Task<AddVisitorResponseDto> AddVisitor(AddVisitorRequestDto addVisitorRequestDto)
        {
            if(!addVisitorRequestDto.IsValid())
            {
                return new AddVisitorResponseDto() { Message = "Invalid data", StatusCode = HttpStatusCode.BadRequest };
            }
            var visitor = VisitorConverter.ToVisitorEntity(addVisitorRequestDto);
            await _visitorRepository.AddVisitorAsync(visitor);
            return new AddVisitorResponseDto() { Message = "asd", StatusCode = HttpStatusCode.OK };
        }
    }
}

