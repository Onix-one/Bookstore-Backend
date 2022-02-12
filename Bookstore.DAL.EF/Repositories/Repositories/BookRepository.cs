using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO.BookModels;
using Bookstore.Core.Models.ModelsDTO.FilterModels;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Interfaces;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL.EF.Repositories.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }

        public override async Task<Book> GetByIdAsync(int id) //TODO get mistake. 
        {
            var result = await _dbSet.Select(x =>
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
                            ImageUrl = y.ImageUrl

                        }).ToList(),
                    Rating = x.Rating,
                    Authors = x.Authors.Select(y =>
                        new Author()
                        {
                            Id = y.Id,
                            FirstName = y.FirstName,
                            SecondName = y.SecondName,
                            Nationality = y.Nationality
                        }).ToList(),
                    GenreOfBooks = x.GenreOfBooks.Select(y =>
                        new GenreOfBook()
                        {
                            Id = y.Id,
                            Name = y.Name
                        }).ToList()
                }).FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<GetMaxAndMinPriceInfo> GetMaxAndMinPriceAsync()
        {
            var getMaxAndMinPriceInfo = new GetMaxAndMinPriceInfo();

            getMaxAndMinPriceInfo.MaxPrice = await _dbSet.Select(x => x.Price).MaxAsync();
            getMaxAndMinPriceInfo.MinPrice = await _dbSet.Select(x=>x.Price).MinAsync();

            return getMaxAndMinPriceInfo;
        }

        public async Task<List<int>> GetAllImagesIdOfBookAsync(int bookId)
        {
            return await _dbSet.Where(x => x.Id == bookId)
                .SelectMany(y => y.Images.Select(q => q.Id))
                .ToListAsync();
        }

        //public async Task<Book> GetBookUrlAndNameAsync(int bookId)
        //{
        //    var RESULT = await _dbSet.Select(x =>
        //        new Book()
        //        {
        //            BookUrl = x.BookUrl,
        //            Name = x.Name
        //        }).FirstOrDefaultAsync(x => x.Id == bookId);

        //    return RESULT;
        //}
        public async Task<List<Book>> GetBooksByFilterAsync(FilterForBookModel conditions)
        {
            IQueryable<Book> books = _dbSet;

            if (!conditions.AuthorsId.IsNullOrEmpty())
            {
                books = books.Where(book =>
                   book.Authors.Any(a => conditions.AuthorsId.Contains(a.Id)));
            }
            if (!conditions.GenresId.IsNullOrEmpty())
            {
                books = books.Where(book =>
                    book.GenreOfBooks.Any(a => conditions.GenresId.Contains(a.Id)));
            }
            if (!conditions.Cost.IsNullOrEmpty())
            {
                // Check in front valid data
                books = books.Where(book => book.Price >= conditions.Cost[0] && book.Price <= conditions.Cost[0]);
            }
            if (conditions.Rating.HasValue)
            {
                books = books.Where(book => book.Rating <= conditions.Rating);
            }

            var result = await books.Select(x => new Book
            {
                Id = x.Id,
                Price = x.Price,
                Name = x.Name,
                Description = x.Description,
                Rating = x.Rating,
                Images = x.Images.Select(y =>
                    new BookImage()
                    {
                        Id = y.Id,
                        ImageUrl = y.ImageUrl

                    }).ToList(),
                Authors = x.Authors.Select(y =>
                    new Author()
                    {
                        Id = y.Id,
                        FirstName = y.FirstName,
                        SecondName = y.SecondName,
                        Nationality = y.Nationality
                    }).ToList(),
                GenreOfBooks = x.GenreOfBooks.Select(y =>
                    new GenreOfBook()
                    {
                        Id = y.Id,
                        Name = y.Name
                    }).ToList()
            }).AsNoTracking()
                .ToListAsync();

            return result;
        }

        public async Task<List<Book>> GetBooksByFilterStoreProcedureAsync(FilterForBookModel conditions)
        {
            throw new Exception();
        }
    }

    public interface IBookRepository : IBaseRepository<Book>
    {
        public Task<List<int>> GetAllImagesIdOfBookAsync(int bookId);

        public Task<GetMaxAndMinPriceInfo> GetMaxAndMinPriceAsync();
        //public Task<Book> GetBookUrlAndNameAsync(int bookId);
        public Task<List<Book>> GetBooksByFilterAsync(FilterForBookModel conditions);
        public Task<List<Book>> GetBooksByFilterStoreProcedureAsync(FilterForBookModel conditions);
    }
}
