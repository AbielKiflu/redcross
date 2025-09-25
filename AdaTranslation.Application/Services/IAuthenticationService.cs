using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.DTOs.Responses;

namespace AdaTranslation.Application.Services
{
    /// <summary>
    /// Auth service using jwt and oauth
    /// </summary>
    public interface IAuthenticationService
    {
        LoginResponseDto Login(UserDto user);
    }
}
