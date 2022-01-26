using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.BookModels;
using Bookstore.Core.Models.ModelsDTO.FilterModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Bookstore.BLL.Interfaces
{
    public interface IBookService
    {
        public Task AddNewBookAsync(CreateNewBookModel book, string rootPath);
        public Task<List<BooksForAuthorFilter>> GetBooksByAuthorAsync(int authorId);
        public Task DeleteBookAsync(int bookId);
        public Task<BookDTO> GetBookByIdAsync(int bookId);
        public Task<LoadBookModel> LoadBookAsync(int bookId);
        public Task<List<BooksByGenreFiltr>> GetBooksByGenresAsync(List<int> genresId);
        public Task<List<BooksAfterFilterModel>> GetBooksByFilterAsync(FilterForBookModel conditions);
    }
}