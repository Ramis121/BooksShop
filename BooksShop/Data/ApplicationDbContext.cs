using Domain.Новая_папка;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Book> books { get; set; }
    }
}
