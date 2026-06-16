using AdaTranslation.Application.Features.Centers.Dtos;
using AdaTranslation.Application.Features.Centers.Queries.GetCenterById;
using AdaTranslation.Application.Features.Centers.Queries.GetCenters;
using AdaTranslation.Domain;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("api/center")]
    [Authorize]
    public class CentersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CentersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("list")]
        public async Task<PagedResult<CenterDto>> GetAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var page = new Page(pageNumber, pageSize);
            var query = new GetCenterQuery(page);

            return await _mediator.Send(query, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<CenterDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetCenterByIdQuery { Id = id }, cancellationToken);
        }
    }

}
