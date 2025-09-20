using AdaTranslation.Application.DTOs.Requests;
using AdaTranslation.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers.Public
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authentication;

        public AuthenticationController(IAuthenticationService authentication)
        {
            _authentication = authentication;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            try
            {
                var result = await _authentication.LoginAsync(request);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }


    }
}
