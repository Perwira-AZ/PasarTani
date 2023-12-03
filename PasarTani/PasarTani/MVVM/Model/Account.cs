using PasarTani.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.MVVM.Model
{
    internal class Account
    {
        protected int _id;
        protected string _name;
        protected string _phone_number;
        protected string _email;
        protected string _password;
        protected int _addressid;
        protected string _image_url;
        protected Address? _address;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string PhoneNumber
        {
            get { return _phone_number; }
            set { _phone_number = value; }
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

        public int AddressId
        {
            get { return _addressid; }
            set { _addressid = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string ImageUrl
        {
            get { return _image_url; }
            set { _image_url = value; }
        }


        bool Authenticate(string password, string email)
        {
            return true;
        }
    }
}
