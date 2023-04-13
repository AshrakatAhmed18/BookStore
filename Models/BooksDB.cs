using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksEccommerce.Models
{
    public class BooksDB : IdentityDbContext<User>
    {
       public  BooksDB() : base()
       { 
        
       }
        
       public BooksDB(DbContextOptions<BooksDB> options) : base(options) { }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            base.OnModelCreating(modelBuilder);
       }

      

        public DbSet<Book> Books { get; set;}
       public DbSet<User> clients { get; set;}

       public DbSet<Book_User> booksUsers { get;set;}
       public DbSet<Category> categories { get;set;}

    }
}
