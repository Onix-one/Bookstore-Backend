using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL.EF.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }

        public async override Task<Book> GetByIdAsync(int id) //TODO get mistake. 
        {
            var result =await  _dbSet.Select(x =>
                new Book()
                {
                    Id = x.Id,
                    Price = x.Price,
                    Name = x.Name,
                    Description = x.Description,
                    Images = x.Images.Select(y =>
                        new BookImage()
                        {
                            Id = y.Id,
                            
                        }).ToList(),
                    Rating = x.Rating,
                    Authors = x.Authors.Select(y=> 
                        new Author()
                        {
                            Id = y.Id,
                            FirstName = y.FirstName,
                            SecondName = y.SecondName,
                            Nationality = y.Nationality
                        }).ToList(),
                    GenreOfBooks = x.GenreOfBooks.Select(y=>
                        new GenreOfBook()
                        {
                            Id = y.Id,
                            Genre = y.Genre
                        } ).ToList()
                }).FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }

    public interface IBookRepository : IBaseRepository<Book>
    {
    }
}
