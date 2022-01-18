using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.DAL.EF.Repositories
{
    public class BookImageRepository : BaseRepository<BookImage>, IBookImageRepository
    {
        public BookImageRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }

        public async Task AddImagesToBookAsync(List<BookImage> images, int bookId)
        {

        }

        public async Task<List<BookImage>> GetAllImagesByBookIdAsync(int bookId)
        {
            throw new Exception();
        }
    }

    public interface IBookImageRepository : IBaseRepository<BookImage>
    {
    }
}
