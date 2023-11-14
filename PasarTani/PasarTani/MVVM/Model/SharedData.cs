using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.MVVM.Model
{
    internal static class SharedData
    {
        public static string connstring = "Host = junpro-db.postgres.database.azure.com; Port=5432;Username=junpro@junpro-db; Password=Wafiuddin1;Database=postgres";
        public static int currentAccountLoginID = 1;
        public static bool isAccountSeller = true; 
    }
}
