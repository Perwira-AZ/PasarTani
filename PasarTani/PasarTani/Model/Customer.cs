using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.Model
{
    internal class Customer
    {
        private int _customerID;
        private string _name;
        private string _phone_number;
        private string _email;
        private string _password;
        private Address _address;
        private Order _order;

        public int CustomerID
        {
            get { return _customerID; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string PhoneNumber
        {
            get { return _phone_number; }
        }

        public string Email
        {
            get { return _email; }
        }

        public string Password
        {
            get { return _password; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public Order Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public bool Login(string password, string email)
        {
            return false;
        }

        public void Buy(Item item, int quantity)
        {

        }

        public bool Bargain(string item, int quantity)
        {
            return true;
        }
    }
}
