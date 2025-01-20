using books_list_api.Data.Models;
using books_list_api.Data.Services;
using books_list_api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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
                if (StringStartWithNumber(publisher.Name)) throw new PublisherNameException(
                    "The publisher start with number",
                    publisher.Name
                    );

                Publisher? publisherCreated = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), publisherCreated);
            }
            catch(PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, {ex._publisherName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-publisher-byId/{publisherId}")]
        public IActionResult GetPublisherById(int publisherId)
        {
            throw new Exception("This is test exception for built in middleware");
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

        private bool StringStartWithNumber(string name)
        {
            return Regex.IsMatch(name, @"^\d");
        }
    }
}
