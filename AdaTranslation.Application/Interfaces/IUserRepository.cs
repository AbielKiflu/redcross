using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Queries.User;

namespace AdaTranslation.Domain.Interfaces
{
    /// <summary>
    ///  A repo to make a crud on the table user
    /// </summary>
    public interface IUserRepository
    {  
        Task<UserDto> GetByLogin(UserLoginRequest request, CancellationToken cancellationToken);
        Task CreateAsync(UserCreateCommand request, CancellationToken cancellationToken);
        Task UpdateAsync(UserUpdateCommand request, CancellationToken cancellationToken);

    }
}
