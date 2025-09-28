using AdaTranslation.Application.DTOs;

namespace AdaTranslation.Application.Interfaces
{
    public interface IUserQueryService
    {
        Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
