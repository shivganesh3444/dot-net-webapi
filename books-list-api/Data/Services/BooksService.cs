﻿using books_list_api.Data.Models;

namespace books_list_api.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBookAuthor(BookVM book)
        {
            Book bookSave = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                CoverUrl = book.CoverUrl,
                Genre = book.Genre,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId,
            };
            
            _context.Books.Add(bookSave);
            _context.SaveChanges();

            if (bookSave.Id > 0)
            {
                foreach (int authorID in book.Authors)
                {
                    Book_Author book_Author = new Book_Author()
                    {
                        BookID = bookSave.Id,
                        AuthorID = authorID
                    };

                    _context.Book_Authors.Add(book_Author);
                    _context.SaveChanges();
                }
            }

        }

        public List<Book> GetAllBooks() => _context.Books.ToList();

        public BookWithAuthorVM? GetBookWithAuthor(int id)
        {
            BookWithAuthorVM? bookWithAuthor = _context.Books.Where(b => b.Id == id).Select(book => new BookWithAuthorVM
            {
                Title = book.Title,
                Description = book.Description,
                CoverUrl = book.CoverUrl,
                Genre = book.Genre,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                PublisherName = book.Publishers.Name,
                Authors = book.Book_Authors.Select(ba => ba.Author.Fullname).ToList()
            }).FirstOrDefault();

            return bookWithAuthor;
        }

        public void UpdateBook(int id, BookVM book) {

            Book? _book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (_book != null) {
               
                    _book.Title = book.Title;
                    _book.Description = book.Description;
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
