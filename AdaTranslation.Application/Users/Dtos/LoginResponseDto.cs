namespace AdaTranslation.Application.Users.Dtos
{
    public record LoginResponseDto
    (
        long Id,
        string FullName,
        string Email,
        string Token,
        string Role,
        string? Center,
        DateTime ExpiresAt
     );

}
