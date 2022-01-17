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
    public interface IRepositoryFactory<TModel> where TModel : BaseProduct
    {
        IRepository<TModel> GetRepository();
    }
}
