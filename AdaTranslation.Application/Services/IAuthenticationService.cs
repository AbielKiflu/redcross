using AdaTranslation.Application.DTOs.Requests;
using AdaTranslation.Application.DTOs.Responses;

namespace AdaTranslation.Application.Services
{
    /// <summary>
    /// Auth service using jwt and oauth
    /// </summary>
    public interface IAuthenticationService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}
