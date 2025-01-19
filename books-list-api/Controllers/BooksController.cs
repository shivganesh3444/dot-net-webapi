using books_list_api.Data.Models;
using books_list_api.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace books_list_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet("get-book-with-author/{id}")]
        public IActionResult GetBookWithAuthor(int id)
        {

            BookWithAuthorVM? book = _booksService.GetBookWithAuthor(id);
            return Ok(book);
        }

        [HttpGet("get-allbooks")]
        public IActionResult GetAllBook()
        {
            List<Book> books = _booksService.GetAllBooks();
            return Ok(books);
        }

        [HttpPost("add-bookauthor")]
        public IActionResult AddBookAuthor([FromBody]BookVM book)
        {
            _booksService.AddBookAuthor(book);
            return Ok();
        }

        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBook(int id, [FromBody]BookVM book)
        {
            _booksService.UpdateBook(id, book);
            return Ok(book);
        }

        [HttpDelete("delete-book/{id}")]
        public IActionResult DeleteBook(int id) { 
            
            _booksService.DeleteBook(id);
            return Ok();
        }
    }
}
