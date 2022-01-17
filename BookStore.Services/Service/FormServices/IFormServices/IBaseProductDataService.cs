using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Service.FormServices.IFormServices
{
    public interface IBaseProductDataService
    {
        public string Name { get; set; }

        public string Price { get; set; }

        public string Quantity { get; set; }

        public string Isbn { get; set; }

    }
}
