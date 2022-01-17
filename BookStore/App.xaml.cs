using BookStore.Infra.Context;
using BookStore.Infra.Worker;
using BookStore.Services.Service;
using BookStore.Services.Service.IService;
using BookStore.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider{ get; set; }

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        public void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<BookStoreDbContext>(options =>
            {
                options.UseSqlServer(DbConfig.GetConnectionString(DbTechnology.Sql));
            });

            //services.AddSingleton(new BookStoreDbContextFactory(SQL_CONNECTION_STR));

            //registering all the view models
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<ReportViewModel>();
            services.AddSingleton<NavigationViewModel>(); 
            services.AddSingleton<AddProductViewModel>();

            //registering all the services
            services.AddTransient<IStore, Store>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IProductCRUDService, ProductCRUDService>();
            //services.AddTransient<Services.Service.FormServices.IFormServices.IFormService, FormService>();


            //registering all the windows
            services.AddTransient<MainWindow>();

            FrameNavigationService.SetupNavigation(services);
        }

        private void OnStartUp(object sender, StartupEventArgs startupEventArgs)
        {
            var mainWindow = ServiceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
