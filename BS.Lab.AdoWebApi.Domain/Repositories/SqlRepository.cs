using BS.Lab.AdoWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BS.Lab.AdoWebApi.Domain.Repositories
{
    public abstract class SqlRepository
    {
        private readonly DbContext dbContext;

        public SqlRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException($"'{nameof(dbContext)}' cannot be Null.", nameof(dbContext));
            }

            this.dbContext = dbContext;
        }

        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(dbContext.ConnectionString);
        }

        protected string GetFieldString(SqlDataReader reader, string columnName)
        {
            var columnOrdinal = reader.GetOrdinal(columnName);
            if (reader.IsDBNull(columnOrdinal)) return null;
            var result = reader.GetString(columnOrdinal);
            return result;
        }

        protected int GetFieldInt(SqlDataReader reader, string columnName)
        {
            var columnOrdinal = reader.GetOrdinal(columnName);
            ThrowExceptionIfNull(reader, columnName, columnOrdinal);
            var result = reader.GetInt32(columnOrdinal);
            return result;
        }

        protected static void ThrowExceptionIfNull(SqlDataReader reader, string columnName, int columnOrdinal)
        {
            if (reader.IsDBNull(columnOrdinal)) throw new Exception($"The field '{columnName}' is unexpected NULL.");
        }

        protected bool IsDbNull(SqlDataReader reader, string columnName)
        {
            var columnOrdinal = reader.GetOrdinal(columnName);
            return reader.IsDBNull(columnOrdinal);
        }

        protected DateTime? GetFieldDateTimeNullable(SqlDataReader reader, string columnName)
        {
            var columnOrdinal = reader.GetOrdinal(columnName);
            if (reader.IsDBNull(columnOrdinal)) return null;
            var result = reader.GetDateTime(columnOrdinal);
            return result;
        }

        protected DateTime GetFieldDateTime(SqlDataReader reader, string columnName)
        {
            var columnOrdinal = reader.GetOrdinal(columnName);
            ThrowExceptionIfNull(reader, columnName, columnOrdinal);
            var result = reader.GetDateTime(columnOrdinal);
            return result;
        }
    }
}
