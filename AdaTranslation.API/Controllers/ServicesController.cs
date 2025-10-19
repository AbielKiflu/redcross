using AdaTranslation.Application.Services.Commands.CreateService;
using AdaTranslation.Application.Services.Commands.DeleteService;
using AdaTranslation.Application.Services.Commands.UpdateService;
using AdaTranslation.Application.Services.Queries.GetServiceById;
using AdaTranslation.Application.Services.Queries.GetServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController: ControllerBase
    {
        private readonly IMediator _mediator;
        public ServicesController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken = default)
        {
            var query = await _mediator.Send(new GetServiceQuery(), cancellationToken);
            return Ok(query);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id,CancellationToken cancellationToken = default)
        {
            var query = await _mediator.Send(new GetServiceByIdQuery(id), cancellationToken);
            return Ok(query);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteServiceCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
