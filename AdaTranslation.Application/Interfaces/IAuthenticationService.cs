using AdaTranslation.Application.DTOs;

namespace AdaTranslation.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}
