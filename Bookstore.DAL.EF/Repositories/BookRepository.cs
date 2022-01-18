﻿using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bookstore.DAL.EF.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }

        public async override Task<Book> GetByIdAsync(int id) //TODO get mistake. 
        {
            var result = await _dbSet. Include(x => x.Images)
                .Include(x => x.Authors )
                .Include(x => x.GenresOfBook)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }

    public interface IBookRepository : IBaseRepository<Book>
    {
    }
}
