using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models.IModel
{
    public interface IBaseProduct
    {

        int Id { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        int QuantityInStock { get; set; }
        string ISBN { get; set; }

    }
}
