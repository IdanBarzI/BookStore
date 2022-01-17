using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookStore.Services.Service.FormServices.IFormServices
{
    public interface IFormService: IFormValiditionService, IBaseProductDataService, IFormAddProduct, IClearForm
    {
        public Enum SelectedGener { get; set; }

        public Visibility IsBook { get; set; }

        public ActualProducts SelectedP { get; set; }

        public string Author { get; set; }

        public string Summary { get; set; }

        public string Edition { get; set; }
    }
}
