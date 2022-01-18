using Bookstore.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL.EF.Context
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookImage> BookImages { get; set; }
        public virtual DbSet<GenreOfBook> GenresOfBooks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.GenresOfBook)
                .WithMany(x => x.Books);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Authors)
                .WithMany(x => x.Books);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Buyers)
                .WithMany(x => x.BroughtBooks);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.CustomersWantedToBuy)
                .WithMany(x => x.BooksReadyToBuy);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Fans)
                .WithMany(x => x.FavoriteBooks);

            modelBuilder.Entity<Customer>()
                .HasMany(x => x.FavoriteTypes)
                .WithMany(x => x.FansOfGenres);

            modelBuilder.Entity<Author>()
                .HasMany(x => x.GenresOfBooks)
                .WithMany(x => x.Authors);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Images)
                .WithOne(x => x.Book);
        }
    }
}
