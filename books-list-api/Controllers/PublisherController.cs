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
            try
            {
                Publisher? publisherCreated = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), publisherCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-publisher-byId/{publisherId}")]
        public IActionResult GetPublisherById(int publisherId)
        {
            var _response = _publishersService.GetPublisherById(publisherId);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
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
            try
            {
               // throw new ArithmeticException("test exception");
                _publishersService.RemovePublisher(publisherId);
                return Ok();
            }
            catch(ArithmeticException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {

            }
           
        }


    }
}
