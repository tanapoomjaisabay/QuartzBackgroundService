using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuartzBackgroundService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public object Status()
        {
            return new
            {
                status = 200,
                success = true,
                message = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
                error = DateTime.Now
            };
        }
    }
}
