using PasarTani.Model;
using PasarTani.MVVM.Model;
using PasarTani.MVVM.Services;
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
using System.Windows.Shapes;

namespace PasarTani.MVVM.View
{
    /// <summary>
    /// Interaction logic for BuyItemView.xaml
    /// </summary>
    public partial class BuyItemView : Window
    {
        public BuyItemView()
        {
            InitializeComponent();
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine($"ItemID: {((Item)DataContext).ItemID}, ItemName: {detailItemName.Text}, SellerID: {((Item)DataContext).SellerID},Price: {detailItemPrice.Text}, Stock: {detailItemStock.Text}, URL: {((Item)DataContext).ImageURL}");


            Trace.WriteLine(detailItemPrice.Text);
            Trace.WriteLine(detailItemStock.Text);
            //Stock: 800
            //
            int cleanPrice = int.Parse(detailItemPrice.Text.Replace("$", "").Replace(",", "").Replace(".00", ""));
            string[] parts = detailItemStock.Text.Split(':');

            int cleanStock = int.Parse(parts[1].Trim());

            Trace.WriteLine(cleanPrice);
            Trace.WriteLine(cleanStock);

            ItemServices itemServices = new ItemServices();

            string imageUrl = itemServices.GenerateUrlImage(SharedData.temporaryImageFilePath, SharedData.currentAccountLoginID + SharedData.currentAccountName);

            bool status = itemServices.UpdateItem(((Item)DataContext).ItemID, detailItemName.Text, ((Item)DataContext).SellerID, cleanStock, cleanPrice, imageUrl);

            if (status)
            {
                MessageBox.Show("Berhasil Beli");
                Close();
            }
            else
            {
                MessageBox.Show("Gagal");
            }
        }
    }
}
