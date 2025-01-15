using books_list_api.Data.Models;

namespace books_list_api.Data.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _dbContext;
        public AuthorsService(AppDbContext dbContext) {
                 _dbContext = dbContext;
        }

        public void AddAuthor(AuthorVM author)
        {
            Author _author = new Author()
            {
                Fullname = author.Fullname
            };
            _dbContext.Authors.Add(_author);
            _dbContext.SaveChanges();
        }
    }
}
