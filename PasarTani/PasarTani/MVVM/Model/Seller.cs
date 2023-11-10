using PasarTani.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.Model
{
    internal class Seller: IUser
    {
        private readonly int _sellerId;
        private string _name;
        private string _phoneNumber;
        private string _email;
        private string _password;
        private Address _address;
        private readonly List<Item> _items;

        public int UserID
        {
            get { return _sellerId; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public List<Item> Items
        {
            get { return _items; }
        }

        string IUser.Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Seller()
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void DeleteItem(Item item)
        {
            _items.Remove(item);
        }

        public void UpdateItem(int itemID, Item updatedItem)
        {
            Item selectItem = _items.Find(i => i.ItemID == itemID);

            if (selectItem != null)
            {
                selectItem.ItemName = updatedItem.ItemName;
                selectItem.Stock = updatedItem.Stock;
                selectItem.Price = updatedItem.Price;
            }
            else
            {
                throw new ArgumentException("Item not found");
            }
        }

        public bool Bargain(int itemID)
        {
            return false; // Add Bargain Logic
        }

        public bool Login(string password, string email)
        {
            return false; // Add Auth Logic
        }
        public bool Authenticate(string password, string email)
        {
            // Authentication logic
            return false;
        }
    }
}
