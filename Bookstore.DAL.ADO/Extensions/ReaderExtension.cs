using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.DAL.ADO.Extensions
{
    public static class ReaderExtension
    {
        public static async Task<string> ReadString(this DbDataReader reader, string nameOfColumn)
        {
            var columnNumber = reader.GetOrdinal(nameOfColumn);

            return await reader.IsDBNullAsync(columnNumber) ? null : reader.GetString(columnNumber);
        }

        public static async Task<int> ReadInt(this DbDataReader reader, string nameOfColumn)
        {
            var columnNumber = reader.GetOrdinal(nameOfColumn);
            return await reader.IsDBNullAsync(columnNumber) ? 0 : reader.GetInt32(columnNumber);
        }

        public static async Task<double> ReadDouble(this DbDataReader reader, string nameOfColumn)
        {
            var columnNumber = reader.GetOrdinal(nameOfColumn);
            return await reader.IsDBNullAsync(columnNumber) ? 0 : reader.GetDouble(columnNumber);
        }
    }
}
