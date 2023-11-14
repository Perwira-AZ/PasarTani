using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.Model
{
    internal class Item
    {
        private int _itemID;
        private string _itemName;
        private int _stock;
        private uint _price;

        public int ItemID
        {
            get { return _itemID; }
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
        public uint Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
