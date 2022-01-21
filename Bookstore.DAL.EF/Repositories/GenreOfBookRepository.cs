using System.Linq;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
