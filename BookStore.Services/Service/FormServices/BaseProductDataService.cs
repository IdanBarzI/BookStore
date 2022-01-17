using BookStore.Services.Service.FormServices.IFormServices;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Service.FormServices
{
    public abstract class BaseProductDataService : ViewModelBase, IBaseProductDataService
    {
        public string Name { get; set; }

        public string Price { get; set; }

        public string Quantity { get; set; }

        public string Isbn { get; set; }

        public string Author { get; set; }

        public string Summary { get; set; }

        public string Edition { get; set; }
    }
}
