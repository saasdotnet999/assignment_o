using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult CheckHealth()
        {
            return Ok("Health check OK");
        }
    }
}
