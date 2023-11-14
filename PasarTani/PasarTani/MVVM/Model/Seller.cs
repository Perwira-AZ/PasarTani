using PasarTani.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.Model
{
    internal class Seller: Account
    {
        private readonly List<Item> _items;

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

        public bool Bargain(int itemID)
        {
            return false; // Add Bargain Logic
        }
    }
}
