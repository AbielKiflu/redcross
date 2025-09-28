namespace AdaTranslation.Application.DTOs
{
    public record UserCreateDto(
        string LastName,
        string FirstName,
        string Telephone,
        string Email,
        UserCenterDto Center,
        string UserRole,
        List<UserLanguageDto> Languages
);
 
}
