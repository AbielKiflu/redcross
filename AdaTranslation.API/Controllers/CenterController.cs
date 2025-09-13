using AdaTranslation.Application.Services;
using AdaTranslation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CenterController : ControllerBase
    {
        private readonly CenterService _centerService;

        public CenterController(CenterService centerService)
        {
            _centerService = centerService;
        }

        [HttpGet]
        public async Task<IEnumerable<Center>> Get()
        {
            return await _centerService.GetAllCentersAsync();
        }
    }

}
