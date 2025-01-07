using books_list_api.Data.Models;

namespace books_list_api.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            Book bookSave = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                Genre = book.Genre,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                DateAdded = DateTime.Now
            };
            
            _context.Books.Add(bookSave);
            _context.SaveChanges();
        }
    }
}
