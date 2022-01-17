using BookStore.Domain.Models;
using BookStore.Domain.Models.IModel;
using BookStore.Infra.Context;
using BookStore.Infra.Worker;
using BookStore.Services.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Service
{
    public class ProductCRUDService : IProductCRUDService
    {
        private readonly IStore _unitOfWork;

        public ProductCRUDService(IStore unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddProduct(IBaseProduct product)
        {
            if (product is Book)
            {
                if (CheckExists(product as Book))
                    _unitOfWork.Books.AddBy(product as Book, product.QuantityInStock);
                else
                    _unitOfWork.Books.Add(product as Book);
            }


            else if (product is Journal)
            {
                if (CheckExists(product as Journal))
                    _unitOfWork.Journals.AddBy(product as Journal, product.QuantityInStock);
                else
                    _unitOfWork.Journals.Add(product as Journal);
            }

            _unitOfWork.Complete();
        }

        public void RemoveProduct(IBaseProduct product, int quntity)
        {
            if (product is Book)
                _unitOfWork.Books.ReduceBy(product as Book, quntity);

            else if (product is Journal)
                _unitOfWork.Journals.ReduceBy(product as Journal, quntity);

            _unitOfWork.Complete();
        }

        public bool CheckExists(IBaseProduct product)
        {
            bool ex = false;
            if (product is Book)
                if (_unitOfWork.Books.Find(p => p.Name == product.Name).FirstOrDefault() != null)
                    ex = true;

                else if (product is Journal)
                    if (_unitOfWork.Journals.Find(p => p.Name == product.Name).FirstOrDefault() != null)
                        ex = true;

            return ex;
        }
    }
}
