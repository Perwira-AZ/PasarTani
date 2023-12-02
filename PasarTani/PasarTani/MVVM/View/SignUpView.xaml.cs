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
using PasarTani.MVVM.Services;

namespace PasarTani.MVVM.View
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        public SignUpView()
        {
            InitializeComponent();
            this.Loaded += SignUpView_Loaded;
        }
        private NpgsqlConnection conn;
        public static NpgsqlCommand cmd;
        private string sql = null;

        public void SignUpView_Loaded(object sender, RoutedEventArgs e)
        {
            conn = new NpgsqlConnection(SharedData.connstring);
        }
        private void btnSeller_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddressServices addressServices = new AddressServices();
                int addressID = addressServices.AddAddress("", "", "");
                
                
                SellerServices sellerServices = new SellerServices();

                bool status = sellerServices.AddSeller(txtName.Text, txtPhone.Text, txtEmail.Text, passPassword.Password , addressID, "");

                if (status)
                {
                    MessageBox.Show("Akun berhasil dibuat", "Sign Up as Seller", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtName.Text = txtPhone.Text = txtEmail.Text = passPassword.Password = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message, "Sign Up as Seller", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddressServices addressServices = new AddressServices();
                int addressID = addressServices.AddAddress("", "", "");

                CustomerServices customerServices = new CustomerServices();

                bool status = customerServices.AddCustomer(txtName.Text, txtPhone.Text, txtEmail.Text, passPassword.Password, addressID, "");

                if (status)
                {
                    MessageBox.Show("Akun berhasil dibuat", "Sign Up as Customer", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtName.Text = txtPhone.Text = txtEmail.Text = passPassword.Password = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sign Up as Customer", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
