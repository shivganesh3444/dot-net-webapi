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

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher(PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet("get-publisher-book/{publisherId}")]
        public IActionResult GetPublisherWithBook(int publisherId)
        {
            PublisherBookVM? publisherWithBook = _publishersService.GetPublisherWithBook(publisherId);
            return Ok(publisherWithBook);
        }

        [HttpGet("get-publisher-author/{publisherId}")]
        public IActionResult GetPublisherWithAuthor(int publisherId)
        {
            PublisherAuthorVM? publisherWithAuthor = _publishersService.GetPublisherWithAuthor(publisherId);
            return Ok(publisherWithAuthor);
        }

        [HttpDelete("delete-publisher/{publisherId}")]
        public IActionResult RemovePublisher(int publisherId) {
            _publishersService.RemovePublisher(publisherId);
            return Ok();
        }


    }
}
