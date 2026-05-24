using AdaTranslation.Application.Features.Languages.Queries.GetLanguageById;
using AdaTranslation.Application.Features.Languages.Queries.GetLanguages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("api/languages")]
    public class LanguagesController: ControllerBase
    {
        private readonly IMediator _mediator;

        public LanguagesController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken = default) 
        {
            var languages = await _mediator.Send(new LanguageQuery(), cancellationToken);
            return languages == null ? NoContent() : Ok(languages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var language = await _mediator.Send(new LanguageByIdQuery(Id:id), cancellationToken);
            return language == null ? NoContent() : Ok(language);
        }
    }
}
