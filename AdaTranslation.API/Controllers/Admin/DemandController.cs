using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers.Admin
{
    [ApiController]
    public class DemandController : Controller
    {
        [HttpPost]
        [Route("[Controller]/create")]
        public IActionResult CreateDemand()
        {
            return Ok();
        }

        [HttpGet]
        [Route("[Controller]")]
        public IActionResult GetDemand()
        {
            return Ok();
        }

    }
}
