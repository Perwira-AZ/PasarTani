using PasarTani.Model;
using PasarTani.MVVM.Model;
using PasarTani.MVVM.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace PasarTani.MVVM.View
{
    /// <summary>
    /// Interaction logic for SellerView.xaml
    /// </summary>
    public partial class SellerView : UserControl, INotifyPropertyChanged
    {
        public SellerView()
        {
            InitializeComponent();
            DataContext = this;
        }


        //Seller Page
        public event PropertyChangedEventHandler? PropertyChanged;

        private string sellerBoundText;
        public string SellerBoundText
        {
            get { return sellerBoundText; }
            set
            {
                sellerBoundText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SellerBoundText"));
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            OrderServices orderServices = new OrderServices();

            SellerBoundText = "Welcome Back " + SharedData.currentAccountName + "!";
            
            foreach (var item in orderServices.GetAllOrders())
            {
                Trace.WriteLine($"Order ID: {item.OrderID}, Customer ID: {item.CustomerID}, Item ID: {item.ItemID}, AddressID: {item.AddressID}, Quanitty: {item.Quantity}");
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
