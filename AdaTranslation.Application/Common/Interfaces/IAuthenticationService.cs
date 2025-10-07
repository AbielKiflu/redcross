using AdaTranslation.Application.Users.Dtos;

namespace AdaTranslation.Application.Common.Interfaces
{
    /// <summary>
    /// Auth service using jwt and oauth
    /// </summary>
    public interface IAuthenticationService
    {
        LoginResponseDto Login(UserDto user);
    }
}
