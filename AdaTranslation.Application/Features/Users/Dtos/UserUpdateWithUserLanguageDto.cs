using AdaTranslation.Application.Features.Languages.Dtos;
using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.Features.Users.Dtos
{
    public record UserUpdateWithUserLanguageDto(
        long Id,
        string LastName,
        string FirstName,
        string Telephone,
        DateTime? PauseStartDate,
        DateTime? PauseEndDate,
        string? GoogleId,
        int CenterId,
        UserRole UserRole,
        LanguageDto[] Languages)
    :UserUpdateDto(
        Id,
        LastName,
        FirstName,
        Telephone,
        PauseStartDate,
        PauseEndDate,
        GoogleId,
        CenterId,
        UserRole
        );
}
