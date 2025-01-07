using books_list_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace books_list_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}
