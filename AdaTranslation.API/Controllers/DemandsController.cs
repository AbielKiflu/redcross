using AdaTranslation.Application.Demands.Commands.CreateDemand;
using AdaTranslation.Application.Demands.Commands.UpdateDemand;
using AdaTranslation.Application.Demands.Commands.UpdateDemandAdmin;
using AdaTranslation.Application.Demands.Dtos;
using AdaTranslation.Application.Demands.Queries.GetDemandById;
using AdaTranslation.Application.Demands.Queries.GetDemands;
using AdaTranslation.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Page = AdaTranslation.Domain.Page;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("api/demands")]
    public class DemandsController: ControllerBase
    {
        private readonly IMediator _mediator;

        public DemandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<DemandSummaryDto> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetDemandByIdQuery { Id = id }, cancellationToken);
        }

        [HttpGet]
        public async Task<PagedResult<DemandSummaryDto>> GetAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken= default)
        {
            var page = new Page(pageNumber, pageSize);
            var query = new GetDemandsQuery() { Page = page };

            return await _mediator.Send(query, cancellationToken);
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
