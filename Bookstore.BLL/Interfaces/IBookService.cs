using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.FilterModels;

namespace Bookstore.BLL.Interfaces
{
    public interface IBookService
    {
        public Task AddNewBook(Book book);
        public Task<List<BooksForAuthorFilter>> GetBooksByAuthor(int authorId);
        public Task DeleteBook(int bookId);
    }
}