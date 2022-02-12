using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;

namespace Bookstore.DAL.EF.Repositories.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }
    }

    public interface ICustomerRepository : IBaseRepository<Customer>
    {
    }
}
