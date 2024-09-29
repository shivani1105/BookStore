using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring a many-to-many special -> topping relationship that is friendly for serialization
            modelBuilder.Entity<BookAuthor>().HasKey(pst => new { pst.BookISBN, pst.AuthorID });
            modelBuilder.Entity<BookAuthor>().HasOne<Book>().WithMany(ps => ps.Authors);
            modelBuilder.Entity<BookAuthor>().HasOne(pst => pst.Author).WithMany();
        }


    }
}
