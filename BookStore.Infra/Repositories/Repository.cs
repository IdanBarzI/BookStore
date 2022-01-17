using BookStore.Domain.Models;
using BookStore.Domain.Models.IModel;
using BookStore.Infra.Context;
using BookStore.Infra.Repositories.IRepositrories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infra.Repositories
{
    public class Repository<TModel> : IRepository<TModel> where TModel : BaseProduct
    {
        protected readonly BookStoreDbContext Context;

        public Repository(BookStoreDbContext context) => Context = context;


        public TModel GetById(int id) => Context.Set<TModel>().Find(id);

        public IEnumerable<TModel> GetAll() => Context.Set<TModel>().ToList();

        public IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate) => Context.Set<TModel>().Where(predicate);

        public void Add(TModel entity) => Context.Set<TModel>().Add(entity);

        public void AddRange(IEnumerable<TModel> entities) => Context.Set<TModel>().AddRange(entities);

        public void ReduceBy(TModel entity, int quntity)
        {
            var en = GetById(entity.Id);
            en.QuantityInStock -= quntity;
            if (en.QuantityInStock <= 0)
            {
                Remove(entity);
            }
        }

        public void AddBy(TModel entity, int quntity) => Context.Set<TModel>().Where(e => e.Name == entity.Name).FirstOrDefault().QuantityInStock += quntity;

        public void Remove(TModel entity) => Context.Set<TModel>().Remove(entity);

        public void RemoveRange(IEnumerable<TModel> entities) => Context.Set<TModel>().RemoveRange(entities);
    }
}
