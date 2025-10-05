using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.DTOs.Mappers;
using AdaTranslation.Application.Queries.User;
using AdaTranslation.Domain.Interfaces;
using AdaTranslation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdaTranslation.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task CreateAsync(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.Entities.User
            {
                FirstName = request.newUser.FirstName,
                LastName = request.newUser.LastName,
                Email = request.newUser.Email,
                CenterId = request.newUser.CenterId,
                UserRole = request.newUser.UserRole,
                Telephone = request.newUser.Telephone,
            };
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<UserDto> GetByLogin(UserLoginRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ArgumentException("Email is required.");

            var user = await _context.Users
                .AsNoTracking()
                .Include(u => u.Center)
                .Include(u => u.UserLanguages)
                    .ThenInclude(ul => ul.Language)
                .SingleOrDefaultAsync(u => u.Email == request.Email); 

           if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials"); 
            return UserMapper.ToUserDto(user);
        }

        public async Task UpdateAsync(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.Entities.User
            {
                FirstName = request.updateUser.FirstName,
                LastName = request.updateUser.LastName,
                CenterId = request.updateUser.CenterId,
                UserRole = request.updateUser.UserRole,
                Telephone = request.updateUser.Telephone,
            };
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
