using Npgsql;
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
using System.Data;
using Npgsql;
using PasarTani.MVVM.Model;
using System.ComponentModel;

namespace PasarTani
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded+= MainWindow_Loaded;
        }
        private NpgsqlConnection conn;
        public static NpgsqlCommand cmd;
        private string sql = null;

        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            conn = new NpgsqlConnection(SharedData.connstring);
        }

        






    }
}
