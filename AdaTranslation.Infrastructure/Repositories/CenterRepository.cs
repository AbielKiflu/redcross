using AdaTranslation.Application.DTOs;
using AdaTranslation.Domain.Interfaces;
using AdaTranslation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdaTranslation.Infrastructure.Repositories
{
    public class CenterRepository : ICenterRepository
    {
        private readonly ApplicationDbContext _context;

        public CenterRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CenterDto>> GetAll()
        {
            return await _context.Center
         .Include(c => c.Users)
         .Select(c => new CenterDto
         {
             Id = c.ID,
             Description = c.Description,
             Address = c.Address,
             Contact = c.Contact,
             Users = c.Users.Select(u => new UserDto
             {
                 ID = u.ID,
                 FirstName = u.FirstName,
                 LastName = u.LastName,
                 Telephone = u.Telephone,
                 Email  = u.Email
             }).ToList()
         })
         .ToListAsync();
        }
    }
}
