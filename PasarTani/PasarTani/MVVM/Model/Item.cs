using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.Model
{
    internal class Item : INotifyPropertyChanged
    {
        private int _itemID;
        private string _itemName;
        private int _sellerID;
        private int _stock;
        private decimal _price;
        public string _imageURL;

        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public int SellerID
        {
            get { return _sellerID; }
            set { _sellerID = value; }
        }
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string ImageURL
        {
            get { return _imageURL; }
            set { _imageURL = value; }
        }

        private bool _isSelected; // Tambahkan properti IsSelected

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        // Properti lain dari kelas Item
        // ...

        // Implementasi INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
