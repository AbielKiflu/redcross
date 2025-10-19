using AdaTranslation.Application.UserLanguages.Commands.CreateUserLanguage;
using AdaTranslation.Application.UserLanguages.Commands.DeleteUserLanguage;
using AdaTranslation.Application.UserLanguages.Commands.UpdateUserLanguage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserLanguagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserLanguagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserLanguageCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserLanguageCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteUserLanguageCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

    }
}
