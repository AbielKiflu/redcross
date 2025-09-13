using AdaTranslation.Domain.Entities;

namespace AdaTranslation.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<User> HandleGoogleLoginAsync(string token);
    }
}
