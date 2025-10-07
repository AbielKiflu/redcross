using AdaTranslation.Application.Centers.Dtos;
using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Common.Mappers;
using AdaTranslation.Domain;
using AdaTranslation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdaTranslation.Infrastructure.Repositories
{
    public class CenterRepository(ApplicationDbContext context) : ICenterRepository
    {
        private readonly ApplicationDbContext _context= context;
         
        public async Task<PagedResult<CenterDto>> Get(Page page, CancellationToken cancellationToken)
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
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
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

            if (page.PageNumber < 1 || page.PageSize < 1)
                throw new ArgumentException("Invalid paging parameters."); 

            return new PagedResult<CenterDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = page.PageNumber,
                PageSize = page.PageSize
            };

        }

        public async Task<CenterDto> GetById(int id, CancellationToken cancellationToken)
        {
            var result= await _context.Centers
                        .AsNoTracking()
                        .Where(c => c.Id == id)
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
