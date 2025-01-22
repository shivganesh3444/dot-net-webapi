using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace books_list_api.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("1.2")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("get-message"), MapToApiVersion("1.0")]
        public IActionResult Get()
        {
            return Ok("I am from version 1.0");
        }

        [HttpGet("get-message"),MapToApiVersion("1.1")]
        public IActionResult GetV1_1()
        {
            return Ok("I am from version 1.1");
        }

        [HttpGet("get-message"), MapToApiVersion("1.2")]
        public IActionResult GetV1_2()
        {
            return Ok("I am from version 1.2");
        }
    }
}
