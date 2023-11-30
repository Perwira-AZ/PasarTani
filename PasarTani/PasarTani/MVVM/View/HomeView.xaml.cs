using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using PasarTani.MVVM.Services;

namespace PasarTani.MVVM.View
{

    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            CekHarga cekHarga = new CekHarga();
            List<Table> dataList = cekHarga.GetDataList();

            dataGrid.ItemsSource = dataList;
            
        }
    }

    public class Table
    {

        public string no { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public Dictionary<string, string> DateValues { get; set; } = new Dictionary<string, string>();
    }


    public class TableWrapper
    {
        public List<Table> data { get; set; }
    }
}
