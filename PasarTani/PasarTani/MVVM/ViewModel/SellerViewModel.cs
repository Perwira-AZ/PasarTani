using PasarTani.Model;
using PasarTani.MVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.MVVM.ViewModel
{
    internal class SellerViewModel
    {
        private readonly ItemServices _itemServices = new ItemServices();

        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();

        public SellerViewModel()
        {
            LoadItems();
        }

        private void LoadItems()
        {
            var items = _itemServices.getAllItems();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
