namespace AdaTranslation.Application.DTOs.Responses
{
    public class LoginResponseDto
    {
        public long UserId { get; set; }
        public required string FullName { get; set; }
        public required string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
