using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.Core.Entities;
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

        public async Task<List<Book>> GetBooksByAuthor(Author author)
        {
            var sqlExpression = string.Format($"SELECT * FROM Books WHERE AuthorId == @AuthorId");
            List<Book> result = new List<Book>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                var nameParam = new SqlParameter("@AuthorId", author.Id);

                command.Parameters.Add(nameParam);

                var reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var book = new Book();
                        book.Id = reader.GetInt32(0);
                        book.Name = reader.GetString(1);
                        book.Rating = reader.GetInt32(2);
                        book.Price = reader.GetDouble(3);
                        book.Summary = reader.GetString(4); //TODO add images

                        result.Add(book);
                    }
                }

                return result;
            }
        }
    }
}
