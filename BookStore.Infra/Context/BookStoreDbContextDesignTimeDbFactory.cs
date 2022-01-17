using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infra.Context
{
    class BookStoreDbContextDesignTimeDbFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
    {
        public BookStoreDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer("Server=(localdb)\\BookStoreDb; Database=BookStoreDb;Trusted_Connection=True").Options;

            return new BookStoreDbContext(options);
        }
    }
}
