using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.Core.Entities;
using Bookstore.DAL.EF.Repositories.Interfaces;

namespace Bookstore.DAL.ADO.Repositories.Interfaces
{
    public interface IBookRepository: IBaseRepository<Book>
    {
        public Task<List<Book>> GetBooksByAuthor(Author author);
    }
}