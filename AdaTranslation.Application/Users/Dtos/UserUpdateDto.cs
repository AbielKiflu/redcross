using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.Users.Dtos
{
    public record UserUpdateDto(
        long Id,
        string LastName,
        string FirstName,
        string Telephone,
        DateTime? PauseStartDate,
        DateTime? PauseEndDate,
        string? GoogleId,
        int CenterId,
        UserRole UserRole
    );
}
