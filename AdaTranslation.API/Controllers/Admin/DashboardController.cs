using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdaTranslation.API.Controllers.Admin
{
    [Controller]
    [Route("[Controller]")]
    public class DashboardController: ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("admin/dashboard")]
        public IActionResult AdminDashboard()
        {
            return Ok("Admin dashboard data");
        }

    }
}
