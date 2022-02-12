using System;
using System.Threading.Tasks;
using Bookstore.DAL.EF.Repositories.Repositories;

namespace Bookstore.DAL.EF.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository{ get; }
        IBookImageRepository BookImageRepository { get; }
        IGenreOfBookRepository GenreOfBookRepository{ get; }
        public Task SaveAsync();
    }
}