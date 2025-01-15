using books_list_api.Data.Models;

namespace books_list_api.Data.Services
{
    public class PublishersService
    {
        private readonly AppDbContext _dbContext;
        public PublishersService(AppDbContext dbContext) {
            _dbContext = dbContext;
        }

        public void AddPublisher(PublisherVM publisher) {
            Publisher _publisher = new Publisher()
            {
                Name = publisher.Name
            };

            _dbContext.Publishers.Add(_publisher);
            _dbContext.SaveChanges();
        }
    }
}
