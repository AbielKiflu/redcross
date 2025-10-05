using System.Data;

using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.DTOs.Mappers;
using AdaTranslation.Application.Interfaces;
using AdaTranslation.Domain.Entities;
using AdaTranslation.Domain.Enums;
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

        public async Task<IEnumerable<UserDto>> GetByCenterIdAsync(int centerId, CancellationToken cancellationToken)
        {
            var users = await _context.Users
                .AsNoTracking()
                .Include(u => u.Center)
                .Include(u => u.UserLanguages)
                    .ThenInclude(ul => ul.Language)
                    .Where(u  => u.CenterId == centerId )
                .ToListAsync(cancellationToken);

            return users.Select(u => UserMapper.ToUserDto(u));
        }

        public async Task<IEnumerable<UserDto>> GetByUserRoleIdAsync(UserRole role, CancellationToken cancellationToken)
        {
            var users = await _context.Users
              .AsNoTracking()
              .Include(u => u.Center)
              .Include(u => u.UserLanguages)
                  .ThenInclude(ul => ul.Language)
                  .Where(u => u.UserRole == role)
              .ToListAsync(cancellationToken);

            return users.Select(u => UserMapper.ToUserDto(u));
        }
        public async Task<IEnumerable<UserDto>> GetByCenterIdAndUserRoleAsync(int centerId, UserRole role, CancellationToken cancellationToken)
        {
            var users = await _context.Users
                .AsNoTracking()
                .Include(u => u.Center)
                .Include(u => u.UserLanguages)
                    .ThenInclude(ul => ul.Language)
                    .Where(u => u.CenterId == centerId && u.UserRole == role)
                .ToListAsync(cancellationToken);

            return users.Select(u => UserMapper.ToUserDto(u));
        }

        public async Task<UserDto> GetUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            var user = await _context.Users
              .AsNoTracking()
              .Include(u => u.Center)
              .Include(u => u.UserLanguages)
                  .ThenInclude(ul => ul.Language)
                  .Where(u => u.Id == id)
              .SingleOrDefaultAsync(cancellationToken);

            return user == null ? throw new KeyNotFoundException($"User with ID {id} was not found.") : UserMapper.ToUserDto(user);
        }

        public async Task<UserDto> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _context.Users
             .AsNoTracking()
             .Include(u => u.Center)
             .Include(u => u.UserLanguages)
                 .ThenInclude(ul => ul.Language)
                 .Where(u => u.Email.Equals(email))
             .SingleOrDefaultAsync(cancellationToken);

            return user == null ? throw new KeyNotFoundException($"User with Email {email} was not found.") : UserMapper.ToUserDto(user);
        }
    }
}
