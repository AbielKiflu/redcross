using AdaTranslation.Application.Interfaces;
using AdaTranslation.Domain.Entities;
using Google.Apis.Auth;

namespace AdaTranslation.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<User> HandleGoogleLoginAsync(string token)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(token);

            return null;
        }
    }
}
