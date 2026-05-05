namespace AdaTranslation.Application.Common.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthResponse> AuthenticateAsync(string email, string password, CancellationToken cancellationToken);
    }
}
