using AdaTranslation.Application.Centers.Dtos;
using AdaTranslation.Application.Languages.Dtos;

namespace AdaTranslation.Application.Users.Dtos
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
