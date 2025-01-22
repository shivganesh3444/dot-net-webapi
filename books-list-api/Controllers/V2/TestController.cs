using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace books_list_api.Controllers.V2
{
    [ApiVersion("2.0")]
    //[Route("api/[controller]")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("get-message")]
        public IActionResult Get()
        {
            return Ok("I am from version 2");
        }
    }
}
