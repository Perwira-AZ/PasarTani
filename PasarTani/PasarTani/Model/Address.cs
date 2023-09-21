using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.Model
{
    internal class Address
    {
        private int addressID;
        private string addressName;
        private string city;
        private string province;

        public int AddressID
        {
            get { return addressID; }
        }

        public string AddressName
        {
            get { return addressName; }
        }

        public string City
        {
            get { return city; }
        }

        public string Province
        {
            get { return province; }
        }

        public void SetLocation(string location)
        {
            addressName = location;
        }
    }
}
