using books_list_api.Data.Models;
using books_list_api.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace books_list_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorsService _authorsService;
        public AuthorController(AuthorsService authorsService) {
        _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author) {
            _authorsService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("author-with-books")]
        public IActionResult GetAuthorWithBooks(int authorId)
        {
           AuthorWithBookVM? authorWithBook = _authorsService.GetAuthorWithBooks(authorId);
            return Ok(authorWithBook);
        }
    }
}
