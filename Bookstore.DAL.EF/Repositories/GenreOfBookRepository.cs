using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;

namespace Bookstore.DAL.EF.Repositories
{
    public class GenreOfBookRepository : BaseRepository<GenreOfBook>, IGenreOfBookRepository
    {
        public GenreOfBookRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }
    }

    public interface IGenreOfBookRepository : IBaseRepository<GenreOfBook>
    {
    }
}
