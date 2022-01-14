using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.BLL.Models;
using Bookstore.Core.Entities;

namespace Bookstore.BLL.Interfaces
{
    public interface IBookService
    {
        public Task AddNewBook(BookDTO book);
        public Task<List<Book>> GetBooksByAuthor(int authorId);
        public Task DeleteBook(int bookId);
    }
}