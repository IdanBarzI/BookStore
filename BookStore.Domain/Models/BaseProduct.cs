using BookStore.Domain.Models.IModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{

    public enum ActualProducts
    {
        Book,
        Journal
    }

    public abstract class BaseProduct : IBaseProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int QuantityInStock { get; set; }

        public string ISBN { get; set; }

        
        public virtual object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }
    }
}
