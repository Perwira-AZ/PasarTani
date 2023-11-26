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

    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
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

        [JsonProperty("09/11/2023")]
        public string Date_09_11_2023 { get; set; }

        [JsonProperty("10/11/2023")]
        public string Date_10_11_2023 { get; set; }

        [JsonProperty("13/11/2023")]
        public string Date_13_11_2023 { get; set; }

        [JsonProperty("14/11/2023")]
        public string Date_14_11_2023 { get; set; }

        [JsonProperty("15/11/2023")]
        public string Date_15_11_2023 { get; set; }

        [JsonProperty("16/11/2023")]
        public string Date_16_11_2023 { get; set; }

        [JsonProperty("17/11/2023")]
        public string Date_17_11_2023 { get; set; }
    }

    public class TableWrapper
    {
        public List<Table> data { get; set; }
    }
}
