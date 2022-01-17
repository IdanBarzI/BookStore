using BookStore.Domain.Models;
using BookStore.Domain.Models.IModel;
using BookStore.Extensions;
using BookStore.Services.Service;
using BookStore.Services.Service.FormServices.IFormServices;
using BookStore.Services.Service.IService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookStore.ViewModels
{
    public class AddProductViewModel : FormService
    {
        private readonly IProductCRUDService _crudService;

        public AddProductViewModel(IProductCRUDService crudService)
        {
            _crudService = crudService;
            SelectedGener = BookGenre.Unknown;
        }

        public override void AddProduct(IProductCRUDService crudService = null)
        {
            base.AddProduct(_crudService);
        }
    }
}
