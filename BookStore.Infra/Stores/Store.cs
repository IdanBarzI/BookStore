using BookStore.Domain.Models;
using BookStore.Infra.Context;
using BookStore.Infra.Repositories;
using BookStore.Infra.Repositories.Factories;
using BookStore.Infra.Repositories.IRepositrories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infra.Worker
{
    public class Store : IStore
    {
        private readonly BookStoreDbContext _context;

        public IRepository<Book> Books { get; private set; }

        public IRepository<Journal> Journals { get; private set; }

        public Store(BookStoreDbContext context)
        {
            _context = context;
            Books = new RepositoryFactory<Book>(context).GetRepository();
            Journals = new RepositoryFactory<Journal>(context).GetRepository();
        }


        public int Complete() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
