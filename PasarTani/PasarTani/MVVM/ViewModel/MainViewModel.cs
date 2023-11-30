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
        public RelayCommand SignUpViewCommand { get; set; }
        public RelayCommand LoginViewCommand { get; set; }
        public RelayCommand BuyerViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public SellerViewModel SellerVM { get; set; }
        public SignUpViewModel SignUpVM { get; set; }
        public LoginViewModel LoginVM { get; set; }

        public BuyerViewModel BuyerVM { get; set; }

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
            SignUpVM= new SignUpViewModel();
            LoginVM= new LoginViewModel();
            BuyerVM = new BuyerViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            SellerViewCommand = new RelayCommand(o =>
            {
                CurrentView = SellerVM;
            });

            SignUpViewCommand = new RelayCommand(o =>
            {
                CurrentView = SignUpVM;
            });

            LoginViewCommand = new RelayCommand(o =>
            {
                CurrentView = LoginVM;
            });

            BuyerViewCommand = new RelayCommand(o =>
            {
                CurrentView = BuyerVM;
            });


        }
    }
}
