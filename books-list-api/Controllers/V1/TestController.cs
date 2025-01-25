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
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get_message_1_0"), MapToApiVersion("1.0")]
        public IActionResult Get()
        {
            _logger.LogInformation("Test Controller Visited From get_message_1_0");
            return Ok("I am from version 1.0");
        }

        [HttpGet("get-message_1_1"),MapToApiVersion("1.1")]
        public IActionResult GetV1_1()
        {
            return Ok("I am from version 1.1");
        }

        [HttpGet("get-message_1_2"), MapToApiVersion("1.2")]
        public IActionResult GetV1_2()
        {
            return Ok("I am from version 1.2");
        }
    }
}
