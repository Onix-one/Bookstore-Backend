using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Core.Interfaces;
using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL.EF.Repositories
{
    public abstract class BaseRepository<Model> : IBaseRepository<Model> where Model : BaseModel
    {
        private BookStoreDbContext _bookStoreDbContext;
        private protected DbSet<Model> _dbSet;

        public BaseRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _dbSet = _bookStoreDbContext.Set<Model>();
        }

        public async Task Save(Model model)
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

        public async Task Delete(Model model)
        {
            _dbSet.Remove(model);
            await _bookStoreDbContext.SaveChangesAsync();
        }

        public async Task<List<Model>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Model> GetById(int Id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
