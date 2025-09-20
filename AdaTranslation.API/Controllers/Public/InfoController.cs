using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers.Public
{
    [Controller]
    [Route("[Controller]")]
    public class InfoController: ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("public/info")]
        public IActionResult PublicInfo()
        {
            return Ok("Public info for residents");
        }

    }
}
