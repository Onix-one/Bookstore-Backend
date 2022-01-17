using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO.FilterModels;
using Bookstore.DAL.ADO.Extensions;
using Bookstore.DAL.ADO.Repositories.Interfaces;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories;
using Microsoft.Data.SqlClient;

namespace Bookstore.DAL.ADO.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        //TODO How not to harcode
        string connectionString = @"Data Source=(localdb)\\MSSQLLocalDB;Database=bookStore;Trusted_Connection=True;";

        public BookRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }

        public async Task<List<BooksForAuthorFilter>> GetBooksByAuthor(Author author)
        {
            var sqlExpression = string.Format($"SELECT Books.Id,Books.Rating, Books.Name, Books.Price,Books.Summary, TypeOfBooks.Id, TypeOfBooks.Type,BookImages.Id,BookImages.Image" +
                                              "FROM Authors" +
                                              "JOIN AuthorBook ON AuthorBook.AuthorsId = Authors.Id and AuthorBook.AuthorsId = @AuthorId" +
                                              "JOIN Books ON Books.Id = AuthorBook.BooksId"+
                                              "JOIN BookImages ON BookImages.BookId =Books.Id "+
                                              "JOIN BookTypeOfBook ON BookTypeOfBook.BooksId =Books.Id " +
                                              "JOIN TypeOfBooks ON BookTypeOfBook.TypesOfBookId =TypeOfBooks.Id ");
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
                        book.Summary = await reader.ReadString("Summary");

                        var typeOfbook = new TypeOfBookForAuthorFiltr();
                        typeOfbook.Id = await reader.ReadInt("Id");
                        //typeOfbook.Type = await reader.ReadInt("Type");  // TODO 1. What about enum in database. 2. How to Map
                        book.TypesOfBook.Add(typeOfbook);
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
