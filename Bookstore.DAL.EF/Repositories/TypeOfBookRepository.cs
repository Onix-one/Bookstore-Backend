using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;

namespace Bookstore.DAL.EF.Repositories
{
    public class TypeOfBookRepository : BaseRepository<TypeOfBook>, ITypeOfBookRepository
    {
        public TypeOfBookRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }
    }

    public interface ITypeOfBookRepository
    {
    }
}
