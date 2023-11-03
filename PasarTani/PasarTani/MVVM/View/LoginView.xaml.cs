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
using System.Xml.Linq;

namespace PasarTani.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            this.Loaded += LoginView_Loaded;
        }
        private NpgsqlConnection conn;
        string connstring = "Host=junpropostgresql.postgres.database.azure.com;Port=5432;Username=postgres@junpropostgresql;Password=Informatika1;Database=PasarTaniDB";
        public static NpgsqlCommand cmd;
        private string sql = null;

        public void LoginView_Loaded(object sender, RoutedEventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
        }

        private void btnSeller_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from seller_login(:_email,:_password)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_email", txtEmail.Text);
                cmd.Parameters.AddWithValue("_password", passPassword.Password);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);

                        if (id != 0)
                        {
                            MessageBox.Show($"Selamat Datang, {name}", "Login as Seller", MessageBoxButton.OK, MessageBoxImage.Information);
                            txtEmail.Text = passPassword.Password = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Login as Seller", MessageBoxButton.OK, MessageBoxImage.Error);
                conn.Close();
            }
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from customer_login(:_email,:_password)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_email", txtEmail.Text);
                cmd.Parameters.AddWithValue("_password", passPassword.Password);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);

                        if (id != 0)
                        {
                            MessageBox.Show($"Selamat Datang, {name}", "Login as Customer", MessageBoxButton.OK, MessageBoxImage.Information);
                            txtEmail.Text = passPassword.Password = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Login as Customer", MessageBoxButton.OK, MessageBoxImage.Error);
                conn.Close();
            }
        }
    }
}
