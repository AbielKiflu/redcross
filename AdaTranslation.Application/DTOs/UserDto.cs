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
        CenterDto Center,
        string UserRole,
        List<LanguageDto> Languages
);
 
}
