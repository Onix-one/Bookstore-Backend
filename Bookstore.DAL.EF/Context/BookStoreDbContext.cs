using System.Collections.Generic;
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
                .HasMany(x => x.GenreOfBooks)
                .WithMany(x => x.Books);

            //    .UsingEntity<BookGenreOfBook>(
            //        j => j
            //            .HasOne(x => x.GenreOfBook)
            //            .WithMany(x => x.BookGenreOfBooks)
            //            .HasForeignKey(x => x.GenreOfBookId),
            //        j => j
            //            .HasOne(x => x.Book)
            //            .WithMany(x => x.BookGenreOfBooks)
            //            .HasForeignKey(x => x.BookId),
            //j =>
            //{
            //    j.HasKey(t => new { t.BookId, t.GenreOfBookId });
            //});

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Authors)
                .WithMany(x => x.Books);

            //    .UsingEntity<BookAuthor>(
            //        j => j
            //            .HasOne(x => x.Author)
            //            .WithMany(x => x.BookAuthors)
            //            .HasForeignKey(x => x.AuthorId),
            //        j => j
            //            .HasOne(x => x.Book)
            //            .WithMany(x => x.BookAuthors)
            //            .HasForeignKey(x => x.BookId),
            //        j =>
            //        {
            //            j.HasKey(t => new { t.BookId, t.AuthorId });
            //        });

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
                .HasMany(x => x.GenreOfBooks)
                .WithMany(x => x.Authors);

            //    .UsingEntity<AuthorGenreOfBook>(
            //        j => j
            //            .HasOne(x => x.GenreOfBook)
            //            .WithMany(x => x.AuthorGenreOfBooks)
            //            .HasForeignKey(x => x.GenreOfBookId),
            //        j => j
            //            .HasOne(x => x.Author)
            //            .WithMany(x => x.AuthorGenreOfBooks)
            //            .HasForeignKey(x => x.AuthorId),
            //        j =>
            //        {
            //            j.HasKey(t => new { t.GenreOfBookId, t.AuthorId });
            //        });

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Images)
                .WithOne(x => x.Book);

            //modelBuilder.Entity<BookAuthor>()
            //    .HasOne(pt => pt.Author)
            //    .WithMany(p => p.BookAuthors)
            //    .HasForeignKey(pt => pt.AuthorId);

            //modelBuilder.Entity<BookAuthor>()
            //        .HasOne(pt => pt.Book)
            //        .WithMany(t => t.BookAuthors)
            //    .HasForeignKey(pt => pt.BookId);

            ////modelBuilder.Entity<AuthorGenreOfBook>()
            ////        .HasOne(pt => pt.Author)
            ////        .WithMany(p => p.AuthorGenreOfBooks)
            ////    .HasForeignKey(pt => pt.AuthorId);

            //modelBuilder.Entity<AuthorGenreOfBook>()
            //        .HasOne(pt => pt.GenreOfBook)
            //        .WithMany(t => t.AuthorGenreOfBooks)
            //    .HasForeignKey(pt => pt.GenreOfBookId);

            //modelBuilder.Entity<BookGenreOfBook>()
            //    .HasOne(pt => pt.Book)
            //    .WithMany(p => p.BookGenreOfBooks)
            //    .HasForeignKey(pt => pt.BookId);

            //modelBuilder.Entity<BookGenreOfBook>()
            //        .HasOne(pt => pt.GenreOfBook)
            //        .WithMany(t => t.BookGenreOfBooks)
            //    .HasForeignKey(pt => pt.GenreOfBookId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
