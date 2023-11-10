﻿using PasarTani.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.MVVM.Model
{
    internal class Account
    {
        private int _id;
        private string _name;
        private string _phone_number;
        private string _email;
        private string _password;
        private Address _address;
        public int ID
        {
            get { return _id; }
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

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }


        bool Authenticate(string password, string email)
        {
            return true;
        }
    }
}
