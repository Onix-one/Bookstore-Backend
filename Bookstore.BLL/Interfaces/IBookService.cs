using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.BookModels;
using Bookstore.Core.Models.ModelsDTO.FilterModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.BLL.Interfaces
{
    public interface IBookService
    {
        public Task AddNewBookAsync(CreateNewBookModel book);
        public Task<List<BooksForAuthorFilter>> GetBooksByAuthorAsync(int authorId);
        public Task DeleteBookAsync(int bookId);
        public Task<BookDTO> GetBookByIdAsync(int bookId);
    }
}