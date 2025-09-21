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
        public async Task<PagedResult<CenterDto>> Get()
        {
            return await _mediator.Send(new GetCenterQuery());
        }
    }

}
