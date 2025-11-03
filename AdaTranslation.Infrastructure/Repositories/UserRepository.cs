using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Common.Mappers;
using AdaTranslation.Application.Users.Dtos;
using AdaTranslation.Domain.Entities;
using AdaTranslation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
           
            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CenterId = user.CenterId,
                UserRole = user.UserRole,
                Telephone = user.Telephone,
            };

            await _context.Users.AddAsync(newUser, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return newUser.Id;
        }

        public async Task<UserDto> GetByLogin(string email, CancellationToken cancellationToken)
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

        public async Task UpdateAsync(UserUpdateDto user, CancellationToken cancellationToken)
        {
            var result = await _context.Users
           .FirstAsync(u => u.Id == user.Id, cancellationToken);

            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.CenterId = user.CenterId;
            result.UserRole = user.UserRole;
            result.Telephone = user.Telephone; 

            _context.Users.Update(result);

            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
