using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO.BookModels;
using Bookstore.Core.Models.ModelsDTO.FilterModels;
using Bookstore.DAL.ADO.Extensions;
using Bookstore.DAL.ADO.Repositories.Interfaces;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories;
using Microsoft.Data.SqlClient;

namespace Bookstore.DAL.ADO.Repositories
{
    public class BookRepositoryAdo : BaseRepository<Book>, IBookRepositoryAdo
    {
        //TODO How not to harcode
        string connectionString = @"Data Source=(localdb)\\MSSQLLocalDB;Database=bookStore;Trusted_Connection=True;";

        public BookRepositoryAdo(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }

        public async Task<List<BooksForAuthorFilter>> GetBooksByAuthorAsync(Author author)
        {
            var sqlExpression = string.Format($"SELECT Books.Id,Books.Rating, Books.Name, Books.Price,Books.Description, GenresOfBooks.Id, GenresOfBooks.Genre,BookImages.Id,BookImages.Image" +
                                              "FROM Authors" +
                                              "JOIN AuthorBook ON AuthorBook.AuthorsId = Authors.Id and AuthorBook.AuthorsId = @AuthorId" +
                                              "JOIN Books ON Books.Id = AuthorBook.BooksId" +
                                              "JOIN BookImages ON BookImages.BookId =Books.Id " +
                                              "JOIN BookTypeOfBook ON BookTypeOfBook.BooksId =Books.Id " +
                                              "JOIN GenresOfBooks ON BookTypeOfBook.GenresOfBookId =GenresOfBooks.Id ");
            List<BooksForAuthorFilter> result = new List<BooksForAuthorFilter>();
            using (var connection = new SqlConnection(connectionString)) // TODO DI pass sqlConnection
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                var nameParam = new SqlParameter("@AuthorId", author.Id);

                command.Parameters.Add(nameParam);

                var reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    //reader.NextResult();
                    while (await reader.ReadAsync())
                    {
                        var book = new BooksForAuthorFilter();
                        book.Id = await reader.ReadInt("Id");
                        book.Name = await reader.ReadString("Name");
                        book.Rating = await reader.ReadInt("Rating");
                        book.Description = await reader.ReadString("Description");

                        var typeOfbook = new GenreOfBookForAuthorFiltr();
                        typeOfbook.Id = await reader.ReadInt("Id");
                        //typeOfbook.Genre = await reader.ReadInt("Genre");  // TODO 1. What about enum in database. 2. How to Map
                        book.GenresOfBook.Add(typeOfbook);
                        result.Add(book);
                    }
                }
                else
                {
                    throw new SqlNullValueException();
                }
                await connection.CloseAsync();
                return result;
            }
        }
    }
}
