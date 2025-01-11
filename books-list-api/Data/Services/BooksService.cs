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

        public List<Book> GetAllBooks() => _context.Books.ToList();

        public Book? GetBook(int id) => _context.Books.FirstOrDefault(x => x.Id == id);

        public void UpdateBook(int id, BookVM book) {

            Book? _book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (_book != null) {
               
                    _book.Title = book.Title;
                    _book.Description = book.Description;
                    _book.Author = book.Author;
                    _book.CoverUrl = book.CoverUrl;
                    _book.Genre = book.Genre;
                    _book.IsRead = book.IsRead;
                    _book.DateRead = book.DateRead;
                    _book.Rate = book.Rate;
                    _book.DateAdded = DateTime.Now;

                    _context.Update(_book);
                    _context.SaveChanges();
            };

        }
        

        public void DeleteBook(int id)
        {
            Book? _book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
