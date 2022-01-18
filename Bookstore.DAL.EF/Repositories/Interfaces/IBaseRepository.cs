using Bookstore.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.DAL.EF.Repositories.Interfaces
{
    public interface IBaseRepository<Model> where Model : IBaseModel
    {
        public Task SaveAsync(Model model);
        public Task DeleteAsync(Model model);
        public Task<List<Model>> GetAllAsync();
        public Task<Model> GetByIdAsync(int Id);
    }
}
