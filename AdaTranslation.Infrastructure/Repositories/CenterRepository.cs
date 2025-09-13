using AdaTranslation.Application.Interfaces;
using AdaTranslation.Domain.Entities;
using AdaTranslation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdaTranslation.Infrastructure
{
    public class CenterRepository : ICenterRepository
    {
        private readonly ApplicationDbContext _context;

        public CenterRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Center>> GetAll()
        {
           return await _context.Center.ToListAsync();
        }
    }
}
