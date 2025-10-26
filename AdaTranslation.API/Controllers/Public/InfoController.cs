using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers.Public
{
    [ApiController]
    [Route("api/public")]
    public class InfoController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("info")]
        public IActionResult PublicInfo()
        {
            return Ok("Public info for residents");
        }

    }
}
