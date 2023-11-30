using Microsoft.Win32;
using PasarTani.Core;
using PasarTani.Model;
using PasarTani.MVVM.Model;
using PasarTani.MVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace PasarTani.MVVM.ViewModel
{
    internal class SellerViewAddItemModel
    {
        ItemServices itemServices = new ItemServices();
        public ICommand AddItemCommand { get; set; }
        public string? Name { get; set; }
        public string? Stock { get; set; }
        public string? Price { get; set; }


        public SellerViewAddItemModel()
        {
            AddItemCommand = new RelayCommand(AddItem, CanAddItem);
        }

        private bool CanAddItem(object obj)
        {
            return true;
        }

        private void AddItem(object obj)
        {
            string imageUrl = SharedData.temporaryUploadImage;

            if(SharedData.currentAccountLoginID != 0 && SharedData.isAccountSeller == true)
            {
                Trace.WriteLine("Approval Mode");
                int sellerID = SharedData.currentAccountLoginID;
                itemServices.AddItem(Name, sellerID, int.Parse(Stock), decimal.Parse(Price), imageUrl);
            }

        }
    }
}
