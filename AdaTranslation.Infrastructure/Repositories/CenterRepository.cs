using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.DTOs.Mappers;
using AdaTranslation.Application.Queries.Center;
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
            var query = _context.Centers
                        .AsNoTracking()
                        .Include(c => c.Users)
                        .ThenInclude(u => u.UserLanguages)
                        .ThenInclude(ul => ul.Language)
                        .Include(c => c.Users)
                        .ThenInclude(u => u.Center);


            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(c => c.Description)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => new CenterDto
                        (
                            c.Id,
                            c.Description,
                            c.Address,
                            c.Contact,
                            c.Users.Select(u => UserMapper.ToUserDto(u)).ToList()
                            )
                        )
                        .ToListAsync(cancellationToken);

            if (request.PageNumber < 1 || request.PageSize < 1)
                throw new ArgumentException("Invalid paging parameters.");


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
            var result= await _context.Centers
                        .AsNoTracking()
                        .Where(c => c.Id == request.Id)
                         .Select(c => new CenterDto
                            (
                                c.Id,
                                c.Description,
                                c.Address,
                                c.Contact,
                                c.Users.Select(u => UserMapper.ToUserDto(u)).ToList()
                            )
                         )
                         .SingleOrDefaultAsync(cancellationToken);

            if (result == null)
                throw new ArgumentNullException(nameof(result));

            return result;
        }
    }
}
