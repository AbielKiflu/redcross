using AdaTranslation.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController: ControllerBase
    {
        IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
           var users = await _mediator.Send(new UserGetAllQuery(), cancellationToken);
            return Ok(users);
        }


    }
}
