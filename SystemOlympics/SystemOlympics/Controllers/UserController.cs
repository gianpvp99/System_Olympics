using Microsoft.AspNetCore.Mvc;
using System;
using SystemOlympics_Business;
using SystemOlympics_Entity.Request;

namespace SystemOlympics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("login")]

        public async Task<IActionResult> Login(string user, string password)
        {
            try
            {
                return Ok(await new BLogin(_configuration).Login(user, password));
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("list")]

        public async Task<IActionResult> List([FromQuery] string? search, [FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                return Ok(await new BUser(_configuration).List(search?? "", page, pageSize));
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("maintenance")]

        public async Task<IActionResult> Maintenance([FromBody] RUser maintenance)
        {
            try
            {
                return Ok(await new BUser(_configuration).Maintenance(maintenance));
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
