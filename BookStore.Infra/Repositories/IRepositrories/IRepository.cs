using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infra.Repositories.IRepositrories
{
    public interface IRepository<TModel> where TModel : BaseProduct
    {
        TModel GetById(int id);
        IEnumerable<TModel> GetAll();
        IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate);

        void Add(TModel entity);
        void AddRange(IEnumerable<TModel> entities);


        void ReduceBy(TModel entity, int quntity);
        void AddBy(TModel entity, int quntity);
        void Remove(TModel entity);
        void RemoveRange(IEnumerable<TModel> entities);

    }
}
