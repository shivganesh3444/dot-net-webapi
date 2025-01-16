using books_list_api.Data.Models;

namespace books_list_api.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScoped = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScoped.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book
                    {
                        Title = "Title 1",
                        Description="description 1",
                        IsRead = true,
                        DateRead = DateTime.Now,
                        Rate = 21,
                        Genre = "Genre 1",
                        CoverUrl ="url 1",
                        DateAdded = DateTime.Now,
                    },
                    new Book
                    {
                        Title = "Title 2",
                        Description = "description 2",
                        Rate = 22,
                        Genre = "Genre 2",
                        CoverUrl = "url 2",
                        DateAdded = DateTime.Now,
                    }
                    );
                }

                context.SaveChanges();
                
            }
        }
    }
}
