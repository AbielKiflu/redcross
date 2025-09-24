using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Queries;
using AdaTranslation.Domain;
using AdaTranslation.Domain.Interfaces;
using AdaTranslation.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace AdaTranslation.Infrastructure.Repositories
{
    public class CenterRepository(ApplicationDbContext context) : ICenterRepository
    {
        private readonly ApplicationDbContext _context= context;
         
        public async Task<PagedResult<CenterDto>> Get(GetCenterQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Center
                        .AsNoTracking()
                        .Include(c => c.Users);

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(c => c.Description)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => new CenterDto
                {
                    Id = c.Id,
                    Description = c.Description,
                    Address = c.Address,
                    Contact = c.Contact,
                    Users = c.Users.Select(u => new UserDto
                    {
                        ID = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Telephone = u.Telephone,
                        Email = u.Email
                    }).ToList()
                })
                .ToListAsync(cancellationToken);

            return new PagedResult<CenterDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

        }

        public async Task<CenterDto> GetById(GetCenterByIdQuery request, CancellationToken cancellationToken)
        {
            var result= await _context.Center
                        .AsNoTracking()
                        .Where(c => c.Id == request.Id)
                         .Select(c => new CenterDto
                         {
                             Id = c.Id,
                             Description = c.Description,
                             Address = c.Address,
                             Contact = c.Contact,
                             Users = c.Users.Select(u => new UserDto
                             {
                                 ID = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Telephone = u.Telephone,
                                 Email = u.Email
                             }).ToList()
                         })
                .SingleOrDefaultAsync(cancellationToken);
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            return result;
        }
    }
}
