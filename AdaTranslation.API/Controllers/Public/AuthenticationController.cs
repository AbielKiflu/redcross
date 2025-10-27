using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Users.Dtos;
using AdaTranslation.Application.Users.Queries.UserLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers.Public
{
    [ApiController]
    [Route("api/auth")]
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
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                UserDto user = await _mediator.Send(request, cancellationToken);
                return Ok(_authentication.Login(user));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }


    }
}
