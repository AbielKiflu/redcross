using AdaTranslation.Application.Features.Centers.Dtos;
using AdaTranslation.Application.Features.Languages.Dtos;

namespace AdaTranslation.Application.Features.Users.Dtos
{
    public record UserDto(
        long Id,
        string LastName,
        string FirstName,
        string Telephone,
        string Email,
        DateTime? PauseStartDate,
        DateTime? PauseEndDate,
        string? GoogleId,
        CenterBaseDto Center,
        string UserRole,
        List<LanguageDto> Languages
);

}
