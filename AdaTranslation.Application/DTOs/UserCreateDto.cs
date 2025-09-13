using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.DTOs
{
    public record UserCreateDto(
        string LastName,
        string FirstName,
        string Telephone,
        string Email,
        DateTime? PauseStartDate,
        DateTime? PauseEndDate,
        string? GoogleId,
        int CenterId,
        UserRole UserRole
    );
}
