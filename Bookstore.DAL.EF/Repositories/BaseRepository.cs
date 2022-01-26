using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.DAL.EF.Repositories
{
    public abstract class BaseRepository<Model> : IBaseRepository<Model> where Model : BaseModel
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        private protected readonly DbSet<Model> _dbSet;

        protected BaseRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _dbSet = _bookStoreDbContext.Set<Model>();
        }

        public virtual async Task SaveAsync(Model model)
        {
            if (model.Id > 0)
            {
                _dbSet.Update(model);
            }
            else
            {
                _dbSet.Add(model);
            }

            await _bookStoreDbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Model model)
        {
            _dbSet.Remove(model);
            await _bookStoreDbContext.SaveChangesAsync();
        }

        public virtual async Task<List<Model>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<Model> GetByIdAsync(int Id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
