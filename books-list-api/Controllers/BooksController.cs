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

        [HttpGet("get-book/{id}")]
        public IActionResult GetBook(int id)
        {

            Book? book = _booksService.GetBook(id);
            return Ok(book);
        }

        [HttpGet("get-allbooks")]
        public IActionResult GetAllBook()
        {
            List<Book> books = _booksService.GetAllBooks();
            return Ok(books);
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBook(book);
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
