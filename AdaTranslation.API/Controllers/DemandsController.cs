using AdaTranslation.Application.Demands.Commands.CreateDemand;
using AdaTranslation.Application.Demands.Commands.UpdateDemand;
using AdaTranslation.Application.Demands.Commands.UpdateDemandAdmin;

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

        [HttpPut]
        [Route("update-admin")]
        public async Task<IActionResult> UpdateAdmin([FromBody] UpdateDemandAdminCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateDemandCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
