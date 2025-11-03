using AdaTranslation.Application.Languages.Dtos;
using AdaTranslation.Application.UserLanguages.Commands.SyncUserLanguages;
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("api/users")]
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
            var result = await _mediator.Send(new UserGetByEmailQuery(email), cancellationToken);

            return result is null ? NoContent() : Ok(result);
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetByIdAsync( int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new UserGetByIdQuery(id), cancellationToken);
            
            return result is null ? NoContent() : Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> GetAsync(
                        [FromQuery] int? centerId = null,
                        [FromQuery] int? role = null,
                        CancellationToken cancellationToken = default)
        {   
            IEnumerable<UserDto> results;

            var claims = HttpContext.User.Claims
            .Select(c => new { c.Type, c.Value })
            .ToList();

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
        public async Task CreateAsync([FromBody] UserCreateWithUserLanguageDto user, CancellationToken cancellationToken = default)
        {
            var userCreate = new UserCreateDto(
                LastName: user.LastName,
                FirstName: user.FirstName,
                Telephone: user.Telephone,
                Email: user.Email,
                PauseStartDate: null,
                PauseEndDate: null,
                GoogleId: null,
                CenterId: user.CenterId,
                UserRole: user.UserRole
            );

            var userLanguages = user.Languages ?? [];
            var createUserCommand = new UserCreateCommand(userCreate);
            var userId = await _mediator.Send(createUserCommand, cancellationToken);

            if (userId <= 0)
                return;

            if (userLanguages.Length == 0)
                return;

            var languageIds = userLanguages.Select(language => language.Id).ToList();
            var syncLanguageCommand = new SyncUserLanguagesCommand(userId, languageIds);
            await _mediator.Send(syncLanguageCommand, cancellationToken);

        }


        [HttpPut]
        public async Task UpdateAsync([FromBody] UserUpdateWithUserLanguageDto user, CancellationToken cancellationToken = default)
        {
            var updateUser = new UserUpdateDto(
                Id: user.Id,
                LastName: user.LastName,
                FirstName: user.FirstName,
                Telephone: user.Telephone,
                PauseStartDate: null,
                PauseEndDate: null,
                GoogleId: null,
                CenterId: user.CenterId,
                UserRole: user.UserRole
            );

            var userLanguages = user.Languages ?? [];
            var updateUserCommand = new UserUpdateCommand(user);
            await _mediator.Send(updateUserCommand, cancellationToken);


            var languageIds = userLanguages.Select(language => language.Id).ToList();
            var syncLanguageCommand = new SyncUserLanguagesCommand(user.Id, languageIds);
            await _mediator.Send(syncLanguageCommand, cancellationToken);
        }



    }
}
