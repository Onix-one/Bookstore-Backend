using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;
using Bookstore.DAL.ADO.Extensions;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories.Repositories;
using Microsoft.Data.SqlClient;

namespace Bookstore.DAL.ADO.Repositories.Repositories
{
    public class AuthorRepositoryAdo : BaseRepository<Author>, IAuthorRepositoryAdo
    {
        //TODO How not to harcode
        private string connectionString;
        private DatabaseContextAdo _databaseContextAdo;

        public AuthorRepositoryAdo(BookStoreDbContext bookStoreDbContext,
            DatabaseContextAdo databaseContextAdo, string connectionString) : base(bookStoreDbContext)
        {
            _databaseContextAdo = databaseContextAdo;
            this.connectionString = connectionString;
        }

        public async Task<List<Author>> GetAllAuthorsNameSurnameIdAsync()
        {
            var sqlExpression = string.Format("SELECT Authors.Id,Authors.FirstName,Authors.SecondName" +
                                                    " FROM dbo.Authors");

            var authors = new List<Author>();
            await using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand(sqlExpression, connection);

                var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        var author = new Author();
                        author.Id = await reader.ReadInt("Id");
                        author.FirstName = await reader.ReadString("FirstName");
                        author.SecondName = await reader.ReadString("SecondName");

                        authors.Add(author);
                    }
                }
            }
            return authors;
        }
    }

    public interface IAuthorRepositoryAdo
    {
        public Task<List<Author>> GetAllAuthorsNameSurnameIdAsync();
    }
}
