using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL.EF.Context
{
    public  class BookStoreDbContext: DbContext
    {
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookImage> BookImages { get; set; }
        public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }
        public virtual DbSet<TypeOfBook> TypeOfBooks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.TypesOfBook)
                .WithMany(x => x.Books);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Authors)
                .WithMany(x => x.Books);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Authors)
                .WithMany(x => x.Books);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Buyers)
                .WithMany(x => x.BroughtBooks);
            
            modelBuilder.Entity<Book>()
                .HasMany(x => x.ReadyToPay)
                .WithMany(x => x.BooksReadyToBuy);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Fans)
                .WithMany(x => x.FavoriteBooks);

            modelBuilder.Entity<Customer>()
                .HasMany(x => x.FavoriteTypes)
                .WithMany(x => x.FansOfTypes);

            modelBuilder.Entity<Author>()
                .HasMany(x => x.TypesOfBooks)
                .WithMany(x => x.Authors);
        }
    }
}
