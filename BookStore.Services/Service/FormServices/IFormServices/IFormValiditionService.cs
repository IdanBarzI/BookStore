using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Service.FormServices
{
    public interface IFormValiditionService : INotifyPropertyChanged, IDataErrorInfo
    {
        public bool IsValidForm { get; set; }

        void FormValiditionCheck();
    }
}
