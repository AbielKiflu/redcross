using System.Security.Claims;

using AdaTranslation.Application.Features.UserLanguages.Commands.SyncUserLanguages;
using AdaTranslation.Application.Features.Users.Commands.CreateUser;
using AdaTranslation.Application.Features.Users.Commands.UpdateUser;
using AdaTranslation.Application.Features.Users.Dtos;
using AdaTranslation.Application.Features.Users.Queries.GetUserByEmail;
using AdaTranslation.Application.Features.Users.Queries.GetUsers;
using AdaTranslation.Domain;
using AdaTranslation.Domain.Enums;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetByEmailAsync([FromQuery] string email, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new UserGetByEmailQuery(email), cancellationToken);
            return result is null ? NoContent() : Ok(result);
        }

        [HttpGet("list")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PagedResult<UserDto>>> GetUsersAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var page = new Page(pageNumber, pageSize);
            var usersQuery = new GetUsersQuery(page);
            var result = await _mediator.Send(usersQuery, cancellationToken);
            return Ok(result);
        }

        [HttpPost("admin/create")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateAsync([FromBody] UserCreateWithUserLanguageDto user, CancellationToken cancellationToken = default)
        {
            if (!User.IsInRole(UserRole.Admin.ToString()))
                return StatusCode(StatusCodes.Status403Forbidden, "Access forbidden: Admin role required.");

            var userLanguages = user.Languages ?? [];
            if (userLanguages.Length == 0)
                return BadRequest("At least one language must be provided.");

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

            try
            {
                var createUserCommand = new UserCreateCommand(userCreate);
                var userId = await _mediator.Send(createUserCommand, cancellationToken);

                if (userId <= 0)
                    return BadRequest("Failed to create user. Invalid generated User ID.");

                var languageIds = userLanguages.Select(language => language.Id).ToList();
                var syncLanguageCommand = new SyncUserLanguagesCommand(userId, languageIds);
                await _mediator.Send(syncLanguageCommand, cancellationToken);

                return CreatedAtAction(nameof(GetByEmailAsync), new { email = user.Email }, new { message = "User and languages created and synchronized successfully.", userId });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    title = "An error occurred while creating the user or synchronizing languages.",
                    detail = ex.Message
                });
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateAsync([FromBody] UserUpdateWithUserLanguageDto user, CancellationToken cancellationToken = default)
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int loggedInUserId))
                return Unauthorized("User identifier claim is missing or invalid.");

            // Identity Guard Clause (Must be Admin OR the owner of the data)
            if (!(User.IsInRole(UserRole.Admin.ToString()) || loggedInUserId == user.Id))
                return StatusCode(StatusCodes.Status403Forbidden, "Access forbidden: You can only update your own profile unless you are an Admin.");

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

            try
            {
                var updateUserCommand = new UserUpdateCommand(updateUser);
                await _mediator.Send(updateUserCommand, cancellationToken);

                var userLanguages = user.Languages ?? [];
                var languageIds = userLanguages.Select(language => language.Id).ToList();
                var syncLanguageCommand = new SyncUserLanguagesCommand(user.Id, languageIds);
                await _mediator.Send(syncLanguageCommand, cancellationToken);

                return Ok(new { message = "User details and languages successfully updated." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    title = "An error occurred while updating the user profile.",
                    detail = ex.Message
                });
            }
        }
    }
}
