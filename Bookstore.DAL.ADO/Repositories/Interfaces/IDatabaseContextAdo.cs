using System;
using Microsoft.Data.SqlClient;

namespace Bookstore.DAL.ADO.Repositories.Interfaces
{
    public interface IDatabaseContextAdo: IDisposable
    {
        public SqlConnection SqlConnection { get; }
    }
}