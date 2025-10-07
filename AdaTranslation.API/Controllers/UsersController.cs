using AdaTranslation.Application.Users.Commands.CreateUser;
using AdaTranslation.Application.Users.Commands.UpdateUser;
using AdaTranslation.Application.Users.Dtos;
using AdaTranslation.Application.Users.Queries.GetUserByEmail;
using AdaTranslation.Application.Users.Queries.GetUserById;
using AdaTranslation.Application.Users.Queries.GetUsers;
using AdaTranslation.Application.Users.Queries.GetUsersByCenterId;
using AdaTranslation.Application.Users.Queries.GetUsersByRole;
using AdaTranslation.Application.Users.Queries.GetUsersByRoleAndCenterId;
using AdaTranslation.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetByEmailAsync([FromQuery] string email, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest("Email is required.");

            var result = await _mediator.Send(new UserGetByEmailQuery(email), cancellationToken);

            return result is null ? NoContent() : Ok(result);
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetByIdAsync( int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return BadRequest("Invalid ID supplied.");

            var result = await _mediator.Send(new UserGetByIdQuery(id), cancellationToken);
            
            return result is null ? NoContent() : Ok(result);
        }

        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> GetAsync(
                        [FromQuery] int? centerId = null,
                        [FromQuery] int? role = null,
                        CancellationToken cancellationToken = default)
        {
            IEnumerable<UserDto> results;

            if (centerId.HasValue && role.HasValue)
            {
                results = await _mediator.Send(new UserGetByCenterIdAndUserRoleQuery(centerId.Value, (UserRole)role), cancellationToken);
            }
            else if (centerId.HasValue)
            {
                results = await _mediator.Send(new UserGetByCenterIdQuery(centerId.Value), cancellationToken);
            }
            else if (role.HasValue)
            {
                results = await _mediator.Send(new UserGetByUserRoleQuery((UserRole)role.Value), cancellationToken);
            }
            else
            {
                results = await _mediator.Send(new UserGetAllQuery(), cancellationToken);
            }

            return results is null ? NoContent() : Ok(results);
        }

        [HttpPost]
        public async Task CreateAsync([FromBody] UserCreateDto user, CancellationToken cancellationToken = default)
        {
            var command = new UserCreateCommand(user);
            await _mediator.Send(command, cancellationToken);
            //to be fixed
        }


        [HttpPut]
        public async Task UpdateAsync([FromBody] UserUpdateDto user, CancellationToken cancellationToken = default)
        {
            var command = new UserUpdateCommand(user);
            await _mediator.Send(command, cancellationToken);
        }



    }
}
