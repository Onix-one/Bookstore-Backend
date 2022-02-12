using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL.EF.Repositories.Repositories
{
    public class GenreOfBookRepository : BaseRepository<GenreOfBook>, IGenreOfBookRepository
    {
        public GenreOfBookRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }
        public async Task<List<GenreOfBook>> GetAllGenresByPartOfNameAsync(string partOFName)
        {
            return await _dbSet.Where(x => x.Name.ToUpper().StartsWith(partOFName)).ToListAsync();
        }
    }

    public interface IGenreOfBookRepository : IBaseRepository<GenreOfBook>
    {
        public Task<List<GenreOfBook>> GetAllGenresByPartOfNameAsync(string partOfName);
    }
}
