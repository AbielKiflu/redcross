using AdaTranslation.Application.Commands.Queries;
using AdaTranslation.Application.DTOs;
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
        public async Task<IEnumerable<CenterDto>> Get()
        {
           return await _mediator.Send(new GetCenterQuery());
        }
    }

}
