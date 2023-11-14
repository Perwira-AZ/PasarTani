using PasarTani.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.Model
{
    internal class Customer : Account
    {
        private Order _order;

        public Order Order
        {
            get { return _order; }
            set { _order = value; }
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
