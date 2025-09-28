using AdaTranslation.Application.Queries.Service;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController: ControllerBase
    {
        private readonly IMediator _mediator;
        public ServiceController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            var query = await _mediator.Send(new GetServiceQuery(), cancellationToken);
            return Ok(query);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id,CancellationToken cancellationToken = default)
        {
            var query = await _mediator.Send(new GetServiceByIdQuery(id), cancellationToken);
            return Ok(query);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateServiceCommand command)
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
        public async Task<IActionResult> Delete([FromBody] DeleteServiceCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
