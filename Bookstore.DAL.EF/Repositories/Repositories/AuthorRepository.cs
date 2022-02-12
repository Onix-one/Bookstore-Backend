using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL.EF.Repositories.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }

        public override async Task<Author> GetByIdAsync(int id)
        {
            var result = await _dbSet.Select(x =>
                new Author()
                {
                    Id = x.Id,
                    DateOfBirth = x.DateOfBirth,
                    Biografy = x.Biografy,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    Nationality = x.Nationality,
                    Books = x.Books.Select(y =>
                        new Book()
                        {
                            Id = y.Id,
                            Name = y.Name,
                            Rating = y.Rating
                        }).ToList()
                }).FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<List<Author>> GetAllAuthorsByPartOfNameAsync(string partOfName)
        {
            if (partOfName == null)
            {
                throw new ArgumentNullException(nameof(partOfName));
            }

            Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@partOfName", partOfName);
                var authors =await _dbSet.FromSqlRaw("EXECUTE GetAllAuthorsByPartOfName @partOfName", param).ToListAsync();
                return authors;


                //return await _dbSet.Where(t => t.FirstName.ToUpper().StartsWith(partOfName) 
                //                               || t.SecondName.ToUpper().StartsWith(partOfName))
                //    .ToListAsync();
        }
    }

    public interface IAuthorRepository : IBaseRepository<Author>
    {
        public Task<List<Author>> GetAllAuthorsByPartOfNameAsync(string partOFName);
    }
}
