using PasarTani.Core;
using PasarTani.Model;
using PasarTani.MVVM.Services;
using PasarTani.MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PasarTani.MVVM.ViewModel
{
    internal class SellerViewModel
    {
        private readonly ItemServices _itemServices = new ItemServices();
        public ICommand ShowWindowCommand { get; set; }
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();

        public SellerViewModel()
        {
            LoadItems();

            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        private void LoadItems()
        {
            var items = _itemServices.getAllItems();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            var sellerWindow = obj as Window;

            SellerViewAddItem addItemWin = new SellerViewAddItem();
            addItemWin.Owner = sellerWindow;
            addItemWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addItemWin.Show();


        }
    }
}
