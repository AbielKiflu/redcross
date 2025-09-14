using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Interfaces;
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
        public async Task<IEnumerable<CenterDto>> Get()
        {
            return await _centerService.GetAllCentersAsync();
        }
    }

}
