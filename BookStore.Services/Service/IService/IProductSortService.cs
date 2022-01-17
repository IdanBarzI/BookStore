using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Service.IService
{
    public interface IProductSortService
    {
        IEnumerable<BaseProduct> GetAllProduct(Type type);
    }
}
