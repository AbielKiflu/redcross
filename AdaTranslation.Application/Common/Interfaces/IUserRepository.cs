using AdaTranslation.Application.Features.Users.Dtos;
using AdaTranslation.Domain;

namespace AdaTranslation.Application.Common.Interfaces
{
    /// <summary>
    ///  A repo to make a crud on the table user
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Get a user by Email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<UserDto?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);

        /// <summary>
        /// Get users
        /// </summary>
        /// <param name="page"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PagedResult<UserDto>> GetUsersAsync(Page page, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Created User Id</returns>
        Task<long> CreateAsync(UserCreateDto user, CancellationToken cancellationToken);

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpdateAsync(UserUpdateDto user, CancellationToken cancellationToken);

    }
}
