﻿using books_list_api.Data.Models;
using books_list_api.Data.Paging;

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

        //public List<Publisher> GetPublishers(string sortBy)
        //{
        //    var allpublishers = _dbContext.Publishers.OrderBy(p => p.Name).ToList();


        //    //sorting
        //    if (!String.IsNullOrEmpty(sortBy))
        //    {
        //        switch (sortBy)
        //        {
        //            case "name_desc":
        //                allpublishers = allpublishers.OrderByDescending(p => p.Name).ToList();
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //    return allpublishers;
        //}

        public List<Publisher> GetAllPublishers(string sortBy, string searchString, int? pageNumber)
        {
            var allPublishers = _dbContext.Publishers.OrderBy(p => p.Name).ToList();

            //sorting
            if (!String.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                        allPublishers = allPublishers.OrderByDescending(p => p.Name).ToList();
                        break;
                    default:
                        break;
                }
            }

            //filtering
            if (!String.IsNullOrEmpty(searchString))
            {
                allPublishers = allPublishers.Where(p => p.Name.Contains(searchString,
                    StringComparison.CurrentCultureIgnoreCase
                    )).ToList();
            }

            //pagination

            int pageSize = 5;

            allPublishers = PaginatedList<Publisher>.Created(allPublishers.AsQueryable(), pageNumber ?? 1, pageSize);

            return allPublishers;
        }
    }
}
