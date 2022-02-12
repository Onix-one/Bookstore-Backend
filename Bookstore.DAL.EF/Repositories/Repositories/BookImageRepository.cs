using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;

namespace Bookstore.DAL.EF.Repositories.Repositories
{
    public class BookImageRepository : BaseRepository<BookImage>, IBookImageRepository
    {
        public BookImageRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }
    }

    public interface IBookImageRepository : IBaseRepository<BookImage>
    {
    }
}
