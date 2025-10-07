using AdaTranslation.Application.Languages.Queries.GetLanguageById;
using AdaTranslation.Application.Languages.Queries.GetLanguages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LanguageController: ControllerBase
    {
        private readonly IMediator _mediator;

        public LanguageController(IMediator mediator) => _mediator = mediator;

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
