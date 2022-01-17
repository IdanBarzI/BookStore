using BookStore.Domain.Models;
using BookStore.Domain.Models.IModel;
using BookStore.Services.Service.FormServices;
using BookStore.Services.Service.FormServices.IFormServices;
using BookStore.Services.Service.IService;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookStore.Services.Service
{
    public abstract class FormService : FormValiditionService, IFormService
    {
        private Enum selectedGener;
        public Enum SelectedGener
        {
            get { return selectedGener; }
            set
            {
                if (selectedGener != value)
                {
                    selectedGener = value;
                    RaisePropertyChanged();
                }
            }
        }

        private Visibility isBook;
        public Visibility IsBook
        {
            get { return isBook; }
            set
            {
                if (isBook != value)
                {
                    isBook = value;
                    RaisePropertyChanged(nameof(IsBook));
                }
            }
        }

        private ActualProducts selectedP;
        public ActualProducts SelectedP
        {
            get { return selectedP; }
            set
            {
                if (selectedP != value)
                {
                    selectedP = value;
                    if (value == ActualProducts.Book)
                    {
                        IsBook = Visibility.Visible;
                        SelectedGener = BookGenre.ComicBook;
                    }
                    else
                    {
                        IsBook = Visibility.Collapsed;
                        SelectedGener = JournalGenre.Essays;
                    }
                }
            }
        }

        private RelayCommand addProductCommand { get; set; }
        public RelayCommand AddProductCommand
        {
            get
            {
                if (addProductCommand == null)
                {
                    addProductCommand = new RelayCommand(() => AddProduct());
                }

                return addProductCommand;
            }
        }


        public virtual void AddProduct(IProductCRUDService crudService =null)
        {
            if (crudService == null )
            {
                return;
            }
            IBaseProduct product;

            switch (SelectedP)
            {
                case ActualProducts.Book:

                    product = new Book
                    {
                        Name = Name,
                        Price = double.Parse(Price),
                        QuantityInStock = int.Parse(Quantity),
                        ISBN = Isbn,
                        BookGenre = (BookGenre)SelectedGener,
                        Summary = Summary,
                        Author = Author,
                        Edition = Edition
                    };
                    crudService.AddProduct(product);
                    break;

                case ActualProducts.Journal:

                    product = new Journal
                    {
                        Name = Name,
                        Price = double.Parse(Price),
                        QuantityInStock = int.Parse(Quantity),
                        ISBN = Isbn,
                        JournalGenres = (JournalGenre)SelectedGener
                    };
                    crudService.AddProduct(product);
                    break;
                default:
                    break;
            }
            ClearForm();
        }

        public virtual void ClearForm()
        {
            SelectedP = ActualProducts.Book;
            RaisePropertyChanged(nameof(SelectedP));
            Name = "";
            RaisePropertyChanged(nameof(Name));
            Price = "";
            RaisePropertyChanged(nameof(Price));
            Quantity = "";
            RaisePropertyChanged(nameof(Quantity));
            Isbn = "";
            RaisePropertyChanged(nameof(Isbn));
            SelectedGener = BookGenre.Unknown;
            RaisePropertyChanged(nameof(SelectedGener));
            Summary = "";
            RaisePropertyChanged(nameof(Summary));
            Author = "";
            RaisePropertyChanged(nameof(Author));
            Edition = "";
            RaisePropertyChanged(nameof(Edition));
        }
    }
}
