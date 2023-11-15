using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.Model
{
    internal class Order
    {
        private int _orderID;
        private int _customerID;
        private int _itemID;
        private int _quantity;
        private int _addressID;

        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }
        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }

        public int AddressID 
        { 
          get { return _addressID; } 
          set { _addressID = value; } 
        }
    }
}
