using AdaTranslation.Application.Users.Dtos;

namespace AdaTranslation.Application.Common.Interfaces
{
    /// <summary>
    ///  A repo to make a crud on the table user
    /// </summary>
    public interface IUserRepository
    {  
        Task<UserDto> GetByLogin(string email, CancellationToken cancellationToken);
        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Created User Id</returns>
        Task<long> CreateAsync(UserCreateDto user, CancellationToken cancellationToken);
        Task UpdateAsync(UserUpdateDto user, CancellationToken cancellationToken);

    }
}
