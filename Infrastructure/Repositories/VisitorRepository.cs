using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly AppDbContext _context;

        public VisitorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddVisitorAsync(Visitor Visitor)
        {
            _context.Visitors.Add(Visitor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVisitorAsync(int id)
        {
            var Visitor = await _context.Visitors.FindAsync(id);
            if (Visitor == null) return;

            _context.Visitors.Remove(Visitor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Visitor>> GetAllVisitorsAsync()
        {
            return await _context.Visitors.ToListAsync();
        }

        public async Task<Visitor> GetVisitorByIdAsync(int id)
        {
            return await _context.Visitors.FindAsync(id);
        }

        public async Task UpdateVisitorAsync(Visitor Visitor)
        {
            _context.Visitors.Update(Visitor);
            await _context.SaveChangesAsync();
        }
    }
}
