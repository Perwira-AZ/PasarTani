using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.MVVM.Model
{
    internal interface IUser
    {
        int UserID { get; }
        string Name { get; set; }
        string PhoneNumber { get; }
        string Email { get; }
        string Address { get; set; }
        bool Authenticate(string password, string email);
    }
}
