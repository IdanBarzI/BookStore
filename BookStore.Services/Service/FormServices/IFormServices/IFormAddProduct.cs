using BookStore.Domain.Models.IModel;
using BookStore.Services.Service.IService;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Service.FormServices.IFormServices
{
    public interface IFormAddProduct
    {
        public RelayCommand AddProductCommand { get; }

        void AddProduct(IProductCRUDService crudService = null);
    }
}
