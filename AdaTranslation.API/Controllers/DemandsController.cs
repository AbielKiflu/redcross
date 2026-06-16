using AdaTranslation.Application.Features.Demands.Commands.CreateDemand;
using AdaTranslation.Application.Features.Demands.Commands.UpdateDemand;
using AdaTranslation.Application.Features.Demands.Dtos;
using AdaTranslation.Application.Features.Demands.Queries.GetDemandById;
using AdaTranslation.Application.Features.Demands.Queries.GetDemands;
using AdaTranslation.Domain;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Page = AdaTranslation.Domain.Page;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("api/demand")]
    [Authorize]
    public class DemandsController : ControllerBase
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
        [Route("list")]
        public async Task<PagedResult<DemandSummaryDto>> GetAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
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
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateDemandCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
