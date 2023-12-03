using Microsoft.Win32;
using PasarTani.Model;
using PasarTani.MVVM.Model;
using PasarTani.MVVM.Services;
using PasarTani.MVVM.ViewModel;
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
    public partial class SellerView : UserControl
    {
        public SellerView()
        {
            InitializeComponent();
            this.DataContext = new SellerViewModel();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement frameworkElement && frameworkElement.DataContext is Item selectedItem)
            {
                Trace.WriteLine($"Edit clicked for ItemID: {selectedItem.ItemID}, ItemName: {selectedItem.ItemName}, Price: {selectedItem.Price}");


                DetailItem detailItemWindow = new DetailItem();
                detailItemWindow.DataContext = selectedItem;
                detailItemWindow.Show();
            }


        }

    }
}
