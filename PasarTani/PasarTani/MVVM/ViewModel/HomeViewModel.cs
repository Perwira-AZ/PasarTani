using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.MVVM.ViewModel
{
    internal class HomeViewModel
    {
        public string ThreeDaysAgo => DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy");
        public string TwoDaysAgo => DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy");
        public string OneDaysAgo => DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
        public string NowDays => DateTime.Now.ToString("dd/MM/yyyy");
    }
}
