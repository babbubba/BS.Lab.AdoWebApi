using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Lab.AdoWebApi.Domain.Models
{
    public class DbContext
    {
        public DbContext(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException($"'{nameof(connectionString)}' non può essere Null o uno spazio vuoto.", nameof(connectionString));
            }
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}
