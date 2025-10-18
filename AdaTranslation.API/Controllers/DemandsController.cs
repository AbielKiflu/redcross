using AdaTranslation.Application.Demands.Commands.CreateDemand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemandsController: ControllerBase
    {
        private readonly IMediator _mediator;

        public DemandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateDemandCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
