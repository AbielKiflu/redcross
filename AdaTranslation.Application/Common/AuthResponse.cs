namespace AdaTranslation.Application.Common
{
    public record AuthResponse(
        string Token,
        string Email,
        DateTime Expiry
    );
}
