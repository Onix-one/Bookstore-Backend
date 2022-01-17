using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO.FilterModels;
using Bookstore.DAL.EF.Repositories.Interfaces;

namespace Bookstore.DAL.ADO.Repositories.Interfaces
{
    public interface IBookRepository: IBaseRepository<Book>
    {
        public Task<List<BooksForAuthorFilter>> GetBooksByAuthor(Author author);
    }
}