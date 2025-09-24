using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Queries;
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
        public async Task<PagedResult<CenterDto>> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetCenterQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return await _mediator.Send(query);
        }
      
        [HttpGet("{id}")]
        public async Task<CenterDto> GetById(int id)
        {
            return await _mediator.Send(new GetCenterByIdQuery{ Id = id});
        }
    }

}
