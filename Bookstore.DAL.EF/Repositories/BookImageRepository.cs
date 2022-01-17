using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;

namespace Bookstore.DAL.EF.Repositories
{
    public class BookImageRepository : BaseRepository<BookImage>, IBookImageRepository
    {
        public BookImageRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }

        public async Task AddImagesToBook(List<BookImage> images, int bookId)
        {

        }

        public async Task<List<BookImage>> GetAllImagesByBookId(int bookId)
        {
            throw new Exception();
        }
    }

    public interface IBookImageRepository : IBaseRepository<BookImage>
    {
    }
}
