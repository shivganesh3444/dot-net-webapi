using books_list_api.Data.Models;
using books_list_api.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace books_list_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly PublishersService _publishersService;
        public PublisherController(PublishersService publishersService) {
        _publishersService = publishersService;
        }

        [HttpPost]
        public IActionResult AddPublisher(PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }
    }
}
