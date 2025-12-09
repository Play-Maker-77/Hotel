using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IVisitorRepository
    {
        Task<Visitor> GetVisitorByIdAsync(int id);
        Task<IEnumerable<Visitor>> GetAllVisitorsAsync();
        Task AddVisitorAsync(Visitor Visitor);
        Task UpdateVisitorAsync(Visitor Visitor);
        Task DeleteVisitorAsync(int id);
    }
}
