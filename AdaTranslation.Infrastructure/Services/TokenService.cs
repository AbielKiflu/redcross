using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Common.Settings;
using AdaTranslation.Domain.Entities;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AdaTranslation.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _options;

        public TokenService(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string CreateToken(User user)
        {
            var key = Encoding.UTF8.GetBytes(_options.Key);
            var creds = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            );

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim("Center", user.Center?.Description ?? string.Empty),
            new Claim(ClaimTypes.Role, user.UserRole.ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_options.ExpireMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
