using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO.BookModels;
using Bookstore.Core.Models.ModelsDTO.FilterModels;
using Bookstore.DAL.EF.Repositories.Interfaces;

namespace Bookstore.DAL.ADO.Repositories.Interfaces
{
    public interface IBookRepositoryAdo: IBaseRepository<Book>
    {
        public Task<List<BooksForAuthorFilter>> GetBooksByAuthorAsync(Author author);
    }
}