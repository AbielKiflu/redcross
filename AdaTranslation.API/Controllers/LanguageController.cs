using AdaTranslation.Application.Queries.Language;
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
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default) 
        {
            var languages = await _mediator.Send(new LanguageQuery(), cancellationToken);
            return Ok(languages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
        {
            var language = await _mediator.Send(new LanguageByIdQuery(Id:id), cancellationToken);
            return Ok(language);
        }
    }
}
