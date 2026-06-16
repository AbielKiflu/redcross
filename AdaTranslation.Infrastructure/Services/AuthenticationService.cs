using AdaTranslation.Application.Common;
using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Common.Settings;
using AdaTranslation.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AdaTranslation.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService _tokenService;
        private readonly JwtOptions _options;
        private readonly ApplicationDbContext _context;

        public AuthenticationService(ITokenService tokenService,
            IOptions<JwtOptions> options,
            ApplicationDbContext context)
        {
            _tokenService = tokenService;
            _options = options.Value;
            _context = context;
        }

        public async Task<AuthResponse> AuthenticateAsync(string email, string password, CancellationToken cancellationToken)
        {

            var user = await _context.Users
              .AsNoTracking()
              .Include(u => u.Center)
              .Include(u => u.UserLanguages)
                  .ThenInclude(ul => ul.Language)
              .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            var token = _tokenService.CreateToken(user);
            var expires = DateTime.UtcNow.AddMinutes(_options.ExpireMinutes);

            return new AuthResponse(Email: user.Email, Token: token, Expiry: expires);

        }
    }
}
