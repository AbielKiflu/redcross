using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Common.Mappers;
using AdaTranslation.Application.Features.Centers.Dtos;
using AdaTranslation.Application.Features.Users.Dtos;
using AdaTranslation.Domain;
using AdaTranslation.Domain.Entities;
using AdaTranslation.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace AdaTranslation.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> CreateAsync(UserCreateDto user, CancellationToken cancellationToken)
        {

            var newUser = new User(user.FirstName, user.LastName, user.Email, user.Telephone, user.CenterId, user.UserRole);
             
            await _context.Users.AddAsync(newUser, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return newUser.Id;
        }

        public async Task<UserDto?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.");

            var user = await _context.Users
                .AsNoTracking()
                .Include(u => u.Center)
                .Include(u => u.UserLanguages)
                .ThenInclude(ul => ul.Language)
                .SingleOrDefaultAsync(u => u.Email == email); 

           if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials"); 
            return UserMapper.ToUserDto(user);
        }

        public async Task<PagedResult<UserDto>> GetUsersAsync(Page page, CancellationToken cancellationToken)
        {
            var query =_context.Users
               .AsNoTracking()
               .Include(u => u.Center)
               .Include(u => u.UserLanguages)
               .ThenInclude(ul => ul.Language);

            var totalCount = await query.CountAsync(cancellationToken);

            var users = await query.OrderBy(u => u.FirstName)
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
                .Select(u => UserMapper.ToUserDto(u))
                 .ToListAsync(cancellationToken);

            if (page.PageNumber < 1 || page.PageSize < 1)
                throw new ArgumentException("Invalid paging parameters.");

            return new PagedResult<UserDto>
            {
                Items = users,
                TotalCount = totalCount,
                PageNumber = page.PageNumber,
                PageSize = page.PageSize
            };
        }

        public async Task UpdateAsync(UserUpdateDto user, CancellationToken cancellationToken)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            var result = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken);

            if (result is null)
                return;

            result.Update(user.FirstName, user.LastName, user.Telephone, user.CenterId, user.UserRole);

            await _context.SaveChangesAsync(cancellationToken);
        }


    }
}
