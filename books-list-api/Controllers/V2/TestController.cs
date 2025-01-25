using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace books_list_api.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("get-messageV2"), MapToApiVersion("2.0")]
        public IActionResult Get()
        {
            return Ok("I am from version 2");
        }
    }
}
