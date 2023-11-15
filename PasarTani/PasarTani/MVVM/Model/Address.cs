using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.Model
{
    internal class Address
    {
        private int _addressID;
        private string _addressName;
        private string _city;
        private string _province;

        public int AddressID
        {
            get { return _addressID; }
            set { _addressID = value; }
        }

        public string AddressName
        {
            get { return _addressName; }
            set { _addressName = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        public void SetLocation(string location)
        {
            _addressName = location;
        }
    }
}
