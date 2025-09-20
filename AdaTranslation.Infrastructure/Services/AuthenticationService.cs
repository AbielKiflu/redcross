using AdaTranslation.Application.DTOs.Requests;
using AdaTranslation.Application.DTOs.Responses;
using AdaTranslation.Application.Services;
using AdaTranslation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AdaTranslation.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _context.User.SingleOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole.ToString()),
                new Claim("CenterId", user.CenterId.ToString())
            };

            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new LoginResponseDto
            {
                UserId = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Token = tokenHandler.WriteToken(token),
                ExpiresAt = expires
            };
        }
 
    }
}
