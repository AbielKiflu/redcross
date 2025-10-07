using AdaTranslation.Application.Centers.Dtos;
using AdaTranslation.Application.Centers.Queries.GetCenterById;
using AdaTranslation.Application.Centers.Queries.GetCenters;
using AdaTranslation.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CenterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CenterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<PagedResult<CenterDto>> GetAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken=default)
        {
            var page = new Page(pageNumber, pageSize);
            var query = new GetCenterQuery(page);

            return await _mediator.Send(query, cancellationToken);
        }
      
        [HttpGet("{id}")]
        public async Task<CenterDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetCenterByIdQuery{ Id = id}, cancellationToken);
        }
    }

}
