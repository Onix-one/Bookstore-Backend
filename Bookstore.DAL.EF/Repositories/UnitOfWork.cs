using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;
using Bookstore.DAL.EF.Repositories.Repositories;

namespace Bookstore.DAL.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreDbContext _context;
        private AuthorRepository _authorRepository;
        private BookRepository _bookRepository;
        private BookImageRepository _imageRepository;
        private GenreOfBookRepository _genreOfBookRepository;

        public UnitOfWork(BookStoreDbContext context)
        {
            _context = context;
        }

        public IAuthorRepository AuthorRepository =>
            _authorRepository ??= new AuthorRepository(_context);
        public IBookRepository BookRepository =>
            _bookRepository ??= new BookRepository(_context);
        public IBookImageRepository BookImageRepository =>
            _imageRepository ??= new BookImageRepository(_context);
        public IGenreOfBookRepository GenreOfBookRepository =>
            _genreOfBookRepository ??= new GenreOfBookRepository(_context);


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.DisposeAsync();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
