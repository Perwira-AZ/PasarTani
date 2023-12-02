using PasarTani.Model;
using PasarTani.MVVM.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for BuyerView.xaml
    /// </summary>
    public partial class BuyerView : UserControl
    {
        public BuyerView()
        {
            InitializeComponent();
            this.DataContext = new BuyerViewModel();
        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement frameworkElement && frameworkElement.DataContext is Item selectedItem)
            {
                Trace.WriteLine($"Edit clicked for ItemID: {selectedItem.ItemID}, ItemName: {selectedItem.ItemName}, Price: {selectedItem.Price}");

                BuyItemView buyItemWindow = new BuyItemView();
                buyItemWindow.DataContext = selectedItem;
                buyItemWindow.Show();
            }
        }
    }
}
