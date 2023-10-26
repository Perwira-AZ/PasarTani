using System;
using PasarTani.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.MVVM.ViewModel
{
    internal class MainViewModel: Core.ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand SellerViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public SellerViewModel SellerVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            SellerVM = new SellerViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            SellerViewCommand = new RelayCommand(o =>
            {
                CurrentView = SellerVM;
            });
        }
    }
}
