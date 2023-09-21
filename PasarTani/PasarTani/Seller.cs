﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani
{
    internal class Seller
    {
        private int _sellerId;
        private string _name;
        private string _phoneNumber;
        private string _email;
        private string _password;
        private List<Item> _items;


        public int SellerId
        {
            get{ return _sellerId; }
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

        public List<Item> Items
        {
            get { return _items; }
        }

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

        public Boolean Bargain(int itemID) 
        {
            return false; // Add Bargain Logic
        }

        public Boolean Login(string password, string email)
        {
            return false; // Add Auth Logic
        }
    }
}
