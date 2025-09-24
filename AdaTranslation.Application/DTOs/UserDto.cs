namespace AdaTranslation.Application.DTOs
{
    public record UserDto(
        long Id,
        string LastName,
        string FirstName,
        string Telephone,
        string Email
    );
}
