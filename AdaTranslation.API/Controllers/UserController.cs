using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Queries.User;
using AdaTranslation.Domain.Enums;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController: ControllerBase
    {
        IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
                        [FromQuery] int? centerId = null,
                        [FromQuery] int? role = null,
                        CancellationToken cancellationToken = default)
        {
            IEnumerable<UserDto> userDtos;

            if (centerId.HasValue && role.HasValue)
            {
                userDtos = await _mediator.Send(new UserGetByCenterIdAndUserRoleQuery(centerId.Value, (UserRole)role), cancellationToken);
            }
            else if (centerId.HasValue)
            {
                userDtos = await _mediator.Send(new UserGetByCenterIdQuery(centerId.Value), cancellationToken);
            }
            else if (role.HasValue)
            {
                userDtos = await _mediator.Send(new UserGetByUserRoleQuery((UserRole)role.Value), cancellationToken);
            }
            else
            {
                userDtos = await _mediator.Send(new UserGetAllQuery(), cancellationToken);
            }

            return Ok(userDtos);
        }




    }
}
