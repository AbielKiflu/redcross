using AdaTranslation.Application.DTOs;
using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.Interfaces
{
    public interface IUserQueryService
    {
        Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<UserDto>> GetByCenterIdAsync(int centerId,CancellationToken cancellationToken);
        Task<IEnumerable<UserDto>> GetByUserRoleIdAsync(UserRole role,CancellationToken cancellationToken);
        Task<IEnumerable<UserDto>> GetByCenterIdAndUserRoleAsync(int centerId, UserRole role,CancellationToken cancellationToken);
    }
}
