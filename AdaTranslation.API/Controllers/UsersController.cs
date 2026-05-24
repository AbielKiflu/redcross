using AdaTranslation.Application.Features.Users.Dtos;
using AdaTranslation.Application.Features.UserLanguages.Commands.SyncUserLanguages;
using AdaTranslation.Application.Features.Users.Commands.CreateUser;
using AdaTranslation.Application.Features.Users.Commands.UpdateUser;
using AdaTranslation.Application.Features.Users.Queries.GetUserByEmail;
using MediatR;
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
