namespace AdaTranslation.Application.Users.Dtos
{
    public record LoginResponseDto
    (
        long Id,
        string FullName,
        string Token,
        string Role,
        string? Center,
        DateTime ExpiresAt
     );

}
