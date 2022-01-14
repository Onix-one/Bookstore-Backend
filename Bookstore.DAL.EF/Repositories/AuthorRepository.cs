using Bookstore.Core.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;

namespace Bookstore.DAL.EF.Repositories
{
    public class AuthorRepository: BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }
    }

    public interface IAuthorRepository: IBaseRepository<Author>
    {
    }
}
