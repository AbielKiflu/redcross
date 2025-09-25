using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Queries.User;
using AdaTranslation.Application.Services;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers.Public
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authentication;
        private readonly IMediator _mediator;

        public AuthenticationController(
            IAuthenticationService authentication,
            IMediator mediator
            )
        {
            _authentication = authentication;
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            try
            {
                UserDto user = await _mediator.Send(request);
                return Ok(_authentication.Login(user));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }


    }
}
