using AdaTranslation.Application.DTOs.Requests;
using AdaTranslation.Application.DTOs.Responses;

namespace AdaTranslation.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}
