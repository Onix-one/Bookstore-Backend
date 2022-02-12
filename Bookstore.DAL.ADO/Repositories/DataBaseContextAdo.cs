using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.DAL.ADO.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace Bookstore.DAL.ADO.Repositories
{
    public class DatabaseContextAdo : IDatabaseContextAdo
    {

        private SqlConnection _sqlConnection;
        private readonly string _connectionString;

        public DatabaseContextAdo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection SqlConnection
        {
            get
            {
                _sqlConnection ??= new SqlConnection(_connectionString);
                if (_sqlConnection.State != ConnectionState.Open)
                {
                    _sqlConnection.Open();
                }

                return _sqlConnection;
            }
        }

        public void Dispose()
        {
            if (_sqlConnection is { State: ConnectionState.Open })
            {
                _sqlConnection.Close();
            }
        }
    }
}
