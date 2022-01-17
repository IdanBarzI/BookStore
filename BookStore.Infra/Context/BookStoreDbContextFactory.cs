using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infra.Context
{
    public class BookStoreDbContextFactory
    {
        private readonly string _connectionString;

        public BookStoreDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public BookStoreDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options;

            return new BookStoreDbContext(options);
        }
    }
}
