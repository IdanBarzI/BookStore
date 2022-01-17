using BookStore.Domain.Models;
using BookStore.Infra.Context;
using BookStore.Infra.Repositories.IRepositrories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infra.Repositories.Factories
{
    public class RepositoryFactory<TModel> : IRepositoryFactory<TModel> where TModel : BaseProduct
    {
        private readonly BookStoreDbContext _context;

        public RepositoryFactory(BookStoreDbContext context) => _context = context;


        public IRepository<TModel> GetRepository() => new Repository<TModel>(_context);
    }
}
