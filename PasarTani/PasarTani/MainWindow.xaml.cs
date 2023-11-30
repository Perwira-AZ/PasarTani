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
using System.Diagnostics;

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

            /*Trace.WriteLine("Looping Main Window");*/




        }

        public void ContentControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Trace.WriteLine("Data Context Changed Looping Main Window");
        }

        private void ContentControl_LayoutUpdated(object sender, EventArgs e)
        {
            Trace.WriteLine("Looping Main Window");


            if (SharedData.isAccountLogin == true)
            {
                SignUpViewTitleMenu.Visibility = Visibility.Collapsed;
                LoginViewTitleMenu.Visibility = Visibility.Collapsed;

                if (SharedData.isAccountSeller == true)
                {
                    SellerViewTitleMenu.Visibility = Visibility.Visible;
                }
                else
                {
                    BuyerViewTitleMenu.Visibility = Visibility.Visible;
                }
            }
            else
            {
                SellerViewTitleMenu.Visibility = Visibility.Collapsed;
                BuyerViewTitleMenu.Visibility = Visibility.Collapsed;
            }
        }
    }
}
