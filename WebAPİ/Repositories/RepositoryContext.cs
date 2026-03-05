using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using WebAPİ.Models;
using WebAPİ.Repositories.Config;

namespace WebAPİ.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}
