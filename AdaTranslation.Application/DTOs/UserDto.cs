namespace AdaTranslation.Application.DTOs
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
        UserCenterDto Center,
        string UserRole,
        List<UserLanguageDto> Languages
);
 
}
