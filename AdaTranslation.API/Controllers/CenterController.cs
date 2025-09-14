using AdaTranslation.Application.Interfaces;
using AdaTranslation.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CenterController : ControllerBase
    {
        private readonly ICenterService _centerService;

        public CenterController(ICenterService centerService)
        {
            _centerService = centerService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<Center>> Get()
        {
            return await _centerService.GetAllCentersAsync();
        }
    }

}
