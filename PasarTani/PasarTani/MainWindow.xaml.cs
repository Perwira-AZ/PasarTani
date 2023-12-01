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
        }

        private void ContentControl_LayoutUpdated(object sender, EventArgs e)
        {
            Trace.WriteLine("Looping Main Window");


            if (SharedData.isAccountLogin == true)
            {
                SignUpViewTitleMenu.Visibility = Visibility.Collapsed;
                LoginViewTitleMenu.Visibility = Visibility.Collapsed;
                btnSignOut.Visibility = Visibility.Visible;

                lbLoginGreeting.Visibility = Visibility.Visible;
                


                if (SharedData.isAccountSeller == true)
                {
                    SellerViewTitleMenu.Visibility = Visibility.Visible;
                    lbLoginGreeting.Text = "Hello Seller " + SharedData.currentAccountName;
                }
                else
                {
                    BuyerViewTitleMenu.Visibility = Visibility.Visible;
                    lbLoginGreeting.Text = "Hello Customer " + SharedData.currentAccountName;
                }
            }
            else
            {
                SellerViewTitleMenu.Visibility = Visibility.Collapsed;
                BuyerViewTitleMenu.Visibility = Visibility.Collapsed;
                btnSignOut.Visibility = Visibility.Collapsed;

                lbLoginGreeting.Visibility = Visibility.Collapsed;

            }
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            SharedData.isAccountLogin = false;
            SellerViewTitleMenu.Visibility = Visibility.Collapsed;
            BuyerViewTitleMenu.Visibility = Visibility.Collapsed;
            
            SignUpViewTitleMenu.Visibility = Visibility.Visible;
            LoginViewTitleMenu.Visibility = Visibility.Visible;
            
            btnSignOut.Visibility = Visibility.Collapsed;
            lbLoginGreeting.Visibility = Visibility.Collapsed;

            SharedData.currentAccountName = "";
            SharedData.temporaryUploadImage = "";
            SharedData.temporaryImageFilePath = "";
            SharedData.currentAccountLoginID = 0;
        }
    }
}
