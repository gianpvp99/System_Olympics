using Microsoft.AspNetCore.Mvc;
using SystemOlympics_Business;
using SystemOlympics_Entity.Request;

namespace SystemOlympics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportComplexController : Controller
    {
        public IConfiguration _configuration;
        public SportComplexController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        [Route("list")]

        public async Task<IActionResult> List([FromQuery] string? search, [FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                return Ok(await new BSportComplex(_configuration).List(search ?? "", page, pageSize));
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("maintenance")]

        public async Task<IActionResult> Maintenance([FromBody] RSportComplex maintenance)
        {
            try
            {
                return Ok(await new BSportComplex(_configuration).Maintenance(maintenance));
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
