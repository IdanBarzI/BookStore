using BookStore.Domain.Models;
using BookStore.Domain.Models.IModel;
using BookStore.Services.Service.IService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{

    public class ReportViewModel : ViewModelBase
    {
        private readonly IReportService _reportService;
        private readonly IProductCRUDService _crudService;
        private Action UpdateProducts { get; set; }

        private ObservableCollection<IBaseProduct> productsToShow;
        public ObservableCollection<IBaseProduct> ProductsToShow { get => productsToShow; set => Set(ref productsToShow, value); }

        private RelayCommand<object> removeFromProductsCommand { get; set; }
        public RelayCommand<object> RemoveFromProductsCommand
        {
            get
            {
                if (removeFromProductsCommand == null)
                {
                    removeFromProductsCommand = new RelayCommand<object>(RemoveFromProducts);
                }

                return removeFromProductsCommand;
            }
        }

        private bool isQuntityOk;
        public bool IsQuntityOk
        {
            get => int.TryParse(quntityToRemove, out quntityToBeRemoved);
            set => isQuntityOk = value;
        }

        private string quntityToRemove;
        public string QuntityToRemove
        {
            get { return quntityToRemove; }
            set
            {
                quntityToRemove = value;
            }
        }

        private int quntityToBeRemoved;

        private string search;

        public string Search
        {
            get { return search; }
            set
            {
                if (search != value)
                {
                    search = value;
                    if (!string.IsNullOrEmpty(value))
                    {
                        FilterProducts();
                    }
                    else
                    {
                        GetAllProducts(selectedProduct);
                    }
                }
            }
        }


        private ActualProducts selectedProduct;
        public ActualProducts SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if (selectedProduct != value)
                {
                    selectedProduct = value;
                    GetAllProducts(selectedProduct);
                    UpdateProps(selectedProduct);
                }
            }
        }

        private ObservableCollection<string> productPropNames; 
        public ObservableCollection<string> ProductPropNames { get => productPropNames; set => Set(ref productPropNames, value); }

        private string selectedProp;
        public string SelectedProp
        {
            get { return selectedProp; }
            set
            {
                if (selectedProp != value)
                {
                    selectedProp = value;
                    FilterProducts();
                }
            }
        }

        public ReportViewModel(IReportService reportService, IProductCRUDService crudService)
        {
            _reportService = reportService;
            _crudService = crudService;
            _crudService.AddProduct(new Book {       Name = "ad",
                                                     Author="Idan",
                                                     ISBN= new Guid().ToString("D"), 
                                                     QuantityInStock=10 });
            _crudService.AddProduct(new Book { Name = "bd",
                QuantityInStock = 10
            });
            GetAllProducts();


            UpdateProducts += () => GetAllProducts(selectedProduct);
        }

        private void GetAllProducts(ActualProducts actualProducts = ActualProducts.Book) => ProductsToShow = new ObservableCollection<IBaseProduct>(_reportService.GetAllProduct(actualProducts));

        private void UpdateProps(ActualProducts actualProducts = ActualProducts.Book)
        {
            switch (actualProducts)
            {
                case ActualProducts.Book:
                    ProductPropNames = new ObservableCollection<string>(typeof(Book)
                                                                        .GetProperties()
                                                                        .Select(property => property.Name));
                    break;
                case ActualProducts.Journal:
                    ProductPropNames = new ObservableCollection<string>(typeof(Journal)
                                                                        .GetProperties()
                                                                        .Select(property => property.Name));
                    break;
                default:
                    break;
            }
        }

        private void FilterProducts() => ProductsToShow = new ObservableCollection<IBaseProduct>(_reportService.FilterProductsBy(selectedProduct, SelectedProp, search));

        private void RemoveFromProducts(object product)
        {
            if (IsQuntityOk)
            {
                _crudService.RemoveProduct(product as BaseProduct, quntityToBeRemoved);
                ClearQuntity();
                UpdateProducts?.Invoke();
            }
        }

        private void ClearQuntity()
        {
            quntityToBeRemoved = 0;
            quntityToRemove = null;
        }
    }
}
