using BookStore.Services.Service.IService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class NavigationViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private ObservableCollection<object> histori;

        public ObservableCollection<object> Histori { get => histori; set => Set(ref histori, value); }

        private RelayCommand _loadedCommand;
        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                    ?? (_loadedCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("ResultsDataGrid");
                    }));
            }
        }


        private RelayCommand reportCommand;

        public RelayCommand ReportCommand
        {
            get
            {
                return reportCommand
                    ?? (reportCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("ResultsDataGrid");
                    }));
            }
        }

        private RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand
                    ?? (addCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("AddProduct");
                    }));
            }
        }

        private RelayCommand goBackCommand { get; set; }

        public RelayCommand GoBackCommand
        {
            get
            {
                return goBackCommand
                       ?? (goBackCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.GoBack();
                           }));
            }

        }



        public NavigationViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
