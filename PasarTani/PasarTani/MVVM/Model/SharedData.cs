using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.MVVM.Model
{
    internal static class SharedData
    {
        public static string connstring = "Host = satao.db.elephantsql.com; Port=5432;Username=tpnfoxpw; Password=r2osulaec2IWjh_SKje5p-pw3v4TtVhO;Database=tpnfoxpw";
        public static int currentAccountLoginID = 1;
        public static string imageProductEndPoint = "https://ik.imagekit.io/r3ca4mbsw/";
        public static string imagePrivateKey = "private_Q5NMX9nhVm4lB4wWVUrrVkGQEtM=";
        public static string imagePublicKey = "public_fnYJfIF6AzSLRUYoPOp+7L68Pwc=";
        public static string currentAccountName = "";
        public static bool isAccountSeller = true; 
    }
}
