using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL.EF.Repositories.Interfaces
{
    public interface IBaseRepository<Model> where Model: IBaseModel
    {
        public Task Save(Model model);

        public Task Delete(Model model);

        public Task<List<Model>> GetAll();

        public Task<Model> GetById(int Id);
    }
}
