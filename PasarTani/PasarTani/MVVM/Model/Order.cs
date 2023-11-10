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
        private Item _orderItem;
        private int _quantity;
        private Address _orderAddress;

        public int OrderID
        {
            get { return _orderID; }
        }
        public Item OrderItem
        {
            get { return _orderItem; }
            set { _orderItem = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public Address OrderAddress
        {
            get { return _orderAddress; }
            set { _orderAddress = value; }
        }
    }
}
