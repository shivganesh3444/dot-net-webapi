using books_list_api.Data.Models;

namespace books_list_api.Data.Services
{
    public class PublishersService
    {
        private readonly AppDbContext _dbContext;
        public PublishersService(AppDbContext dbContext) {
            _dbContext = dbContext;
        }

        public Publisher AddPublisher(PublisherVM publisher) {
            Publisher _publisher = new Publisher()
            {
                Name = publisher.Name
            };

            _dbContext.Publishers.Add(_publisher);
            _dbContext.SaveChanges();

            return _publisher;
        }

        public Publisher? GetPublisherById(int publisherId) { 
           
            Publisher? publisher = _dbContext.Publishers.Where(p => p.Id == publisherId).FirstOrDefault();
            
            return publisher;
        }

        public PublisherBookVM? GetPublisherWithBook(int publisherId)
        {
            PublisherBookVM? publisherWithBook = _dbContext.Publishers.Where(p => p.Id == publisherId)
                                            .Select(publisher => new PublisherBookVM
                                            {
                                                PublisherId = publisher.Id,
                                                PublisherName = publisher.Name,
                                                Books = publisher.Books.Select(b => b.Title).ToList()
                                            }).FirstOrDefault();

            return publisherWithBook;
        }

        public PublisherAuthorVM? GetPublisherWithAuthor(int publisherId)
        {
            PublisherAuthorVM? publisherWithAuthor = _dbContext.Publishers.Where(p => p.Id == publisherId)
                .Select(publisher => new PublisherAuthorVM { 
                 PublisherId= publisher.Id,
                 PublisherName= publisher.Name,
                 Authors = publisher.Books.Select(b => b.Book_Authors
                                                        .Select(a => a.Author.Fullname)).ToList()
                }).FirstOrDefault();

            return publisherWithAuthor;
        }

        public void RemovePublisher(int publisherId)
        {
            Publisher? publisherToRemove =
                     _dbContext.Publishers.Where(p => p.Id == publisherId).FirstOrDefault();

            if (publisherToRemove != null) {
                _dbContext.Remove(publisherToRemove);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"The publisher with id {publisherId} not found");
            }
       }

        public List<Publisher> GetAllPublishers()
        {
            return _dbContext.Publishers.ToList();
        }
    }
}
