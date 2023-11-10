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
                conn.Open();
                sql = @"select * from seller_insert(:_name,:_phone_number,:_email,:_password)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_name", txtName.Text);
                cmd.Parameters.AddWithValue("_phone_number", txtPhone.Text);
                cmd.Parameters.AddWithValue("_email", txtEmail.Text);
                cmd.Parameters.AddWithValue("_password", passPassword.Password);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Akun berhasil dibuat", "Sign Up as Seller", MessageBoxButton.OK, MessageBoxImage.Information);
                    conn.Close();
                    txtName.Text = txtPhone.Text = txtEmail.Text = passPassword.Password = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message, "Sign Up as Seller", MessageBoxButton.OK, MessageBoxImage.Error);
                conn.Close();
            }
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from customer_insert(:_name,:_phone_number,:_email,:_password)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_name", txtName.Text);
                cmd.Parameters.AddWithValue("_phone_number", txtPhone.Text);
                cmd.Parameters.AddWithValue("_email", txtEmail.Text);
                cmd.Parameters.AddWithValue("_password", passPassword.Password);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Akun berhasil dibuat", "Sign Up as Customer", MessageBoxButton.OK, MessageBoxImage.Information);
                    conn.Close();
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
