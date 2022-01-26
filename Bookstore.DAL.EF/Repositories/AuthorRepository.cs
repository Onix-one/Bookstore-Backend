using System.Linq;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL.EF.Repositories
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
                        }).ToList(),
                    GenreOfBooks = x.GenreOfBooks.Select(y =>
                        new GenreOfBook()
                        {
                            Id = y.Id,
                            Genre = y.Genre
                        }).ToList()
                }).FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }

    public interface IAuthorRepository : IBaseRepository<Author>
    {
    }
}
