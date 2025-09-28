using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.DTOs.Mappers;
using AdaTranslation.Application.Interfaces;
using AdaTranslation.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace AdaTranslation.Infrastructure.Repositories
{
    public class UserQueryService : IUserQueryService
    {
        private readonly ApplicationDbContext _context;
        public UserQueryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var users = await _context.Users
                 .AsNoTracking()
                 .Include(u => u.Center)
                 .Include(u => u.UserLanguages)
                     .ThenInclude(ul => ul.Language)
                 .ToListAsync(cancellationToken);

            return users.Select(u => UserMapper.ToUserDto(u));
        }
    }
}
