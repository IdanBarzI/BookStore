using BookStore.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => App.ServiceProvider?.GetRequiredService<MainViewModel>();
        public ReportViewModel ReportViewModel => App.ServiceProvider?.GetRequiredService<ReportViewModel>();
        public NavigationViewModel Navigation => App.ServiceProvider?.GetRequiredService<NavigationViewModel>(); 
        public AddProductViewModel AddProductViewModel => App.ServiceProvider?.GetRequiredService<AddProductViewModel>(); 
    }
}
