using BookStore.Domain.Models;
using BookStore.Domain.Models.IModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Service.IService
{
    public interface IFilterService
    {
        IEnumerable<IBaseProduct> FilterProductsBy(ActualProducts productEnum, string propertyName, object value);
    }
}
