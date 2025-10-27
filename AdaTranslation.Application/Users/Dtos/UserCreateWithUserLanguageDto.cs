using AdaTranslation.Application.Languages.Dtos;
using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.Users.Dtos
{
    public record UserCreateWithUserLanguageDto(
        string LastName,
        string FirstName,
        string Telephone,
        string Email,
        DateTime? PauseStartDate,
        DateTime? PauseEndDate,
        string? GoogleId,
        int CenterId,
        UserRole UserRole,
        LanguageDto[] Languages)
    :UserCreateDto(
        LastName,
        FirstName,
        Telephone,
        Email,
        PauseStartDate,
        PauseEndDate,
        GoogleId,
        CenterId,
        UserRole
        );
}
