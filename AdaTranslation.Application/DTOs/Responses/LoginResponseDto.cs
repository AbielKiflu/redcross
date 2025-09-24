namespace AdaTranslation.Application.DTOs.Responses
{
    public record LoginResponseDto
    (
        long Id,
        string FullName,
        string Token,
        DateTime ExpiresAt
     );

}
