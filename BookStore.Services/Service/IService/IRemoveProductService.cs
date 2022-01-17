using BookStore.Domain.Models.IModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Service.IService
{
    public interface IRemoveProductService
    {
        void RemoveProduct(IBaseProduct product, int quntity);
    }
}
