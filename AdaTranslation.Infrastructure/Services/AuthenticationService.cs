using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Users.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AdaTranslation.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
         
        private readonly IConfiguration _configuration; 
        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public  LoginResponseDto Login(UserDto user)
        { 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
             
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"]));

            var claims = new[]
           {
                new Claim("ID", user.Id.ToString()),
                new Claim("Name", user.FirstName + user.LastName),
                new Claim("Email", user.Email),
                new Claim("Center", user.Center.Description),
                new Claim("Role", user.UserRole.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new LoginResponseDto
            (
                user.Id,
                $"{user.FirstName} {user.LastName}",
                user.Email,
                tokenHandler.WriteToken(token),
                user.UserRole.ToString(),
                user.Center.Description.ToString(),
                expires
            );
        }
 
    }
}
