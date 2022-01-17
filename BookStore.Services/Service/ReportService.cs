using BookStore.Domain.Models;
using BookStore.Domain.Models.IModel;
using BookStore.Infra.Worker;
using BookStore.Services.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Service
{
    public class ReportService : IReportService
    {
        private readonly IStore _unitOfWork;

        public ReportService(IStore unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public BaseProduct GetProductById(int id, ActualProducts productEnum)
        {
            switch (productEnum)
            {
                case ActualProducts.Book:
                    return _unitOfWork.Books.GetById(id);

                case ActualProducts.Journal:
                    return _unitOfWork.Journals.GetById(id);

                default:
                    return null;
            }
        }

        public IEnumerable<IBaseProduct> GetAllProduct(ActualProducts productEnum)
        {
            switch (productEnum)
            {
                case ActualProducts.Book:
                    return _unitOfWork.Books.GetAll();

                case ActualProducts.Journal:
                    return _unitOfWork.Journals.GetAll();

                default:
                    return null;
            }

        }

        public IEnumerable<IBaseProduct> FilterProductsBy(ActualProducts productEnum, string propertyName, object value)
        {
            List<IBaseProduct> products = new List<IBaseProduct>();

            switch (productEnum)
            {
                case ActualProducts.Book:
                    return _unitOfWork.Books.Find(b => b[propertyName] == value);

                case ActualProducts.Journal:
                    return _unitOfWork.Journals.Find(b => b[propertyName] == value);
                default:
                    break;
            }
            return products;
        }
    }
}
