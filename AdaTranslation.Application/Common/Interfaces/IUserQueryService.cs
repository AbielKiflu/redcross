using AdaTranslation.Application.Users.Dtos;
using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.Common.Interfaces
{
    public interface IUserQueryService
    {
        Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<UserDto>> GetByCenterIdAsync(int centerId,CancellationToken cancellationToken);
        Task<IEnumerable<UserDto>> GetByUserRoleIdAsync(UserRole role,CancellationToken cancellationToken);
        Task<IEnumerable<UserDto>> GetByCenterIdAndUserRoleAsync(int centerId, UserRole role,CancellationToken cancellationToken);
        Task<UserDto> GetUserByIdAsync(int id,CancellationToken cancellationToken);
        Task<UserDto> GetUserByEmailAsync(string email,CancellationToken cancellationToken);
    }
}
