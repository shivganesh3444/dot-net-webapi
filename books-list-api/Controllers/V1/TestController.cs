using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace books_list_api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("get-message")]
        public IActionResult Get()
        {
            return Ok("I am from version 1");
        }
    }
}
