using PasarTani.Model;
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
    /// Interaction logic for DetailItem.xaml
    /// </summary>
    public partial class DetailItem : Window
    {
        public DetailItem()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
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

            bool status = itemServices.UpdateItem(((Item)DataContext).ItemID, detailItemName.Text, ((Item)DataContext).SellerID, cleanStock, cleanPrice, ((Item)DataContext).ImageURL.ToString());

            if(status)
            {
                MessageBox.Show("Berhasil Edit");
                Close();
            }
            else
            {
                MessageBox.Show("Gagal");
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine($"ItemID: {((Item)DataContext).ItemID}, ItemName: {detailItemName.Text}, SellerID: {((Item)DataContext).SellerID},Price: {detailItemPrice.Text}, Stock: {detailItemStock.Text}, URL: {((Item)DataContext).ImageURL}");

            ItemServices itemServices = new ItemServices();

            bool status = itemServices.DeleteItem(((Item)DataContext).SellerID, ((Item)DataContext).ItemID);

            if (status)
            {
                MessageBox.Show("Berhasil Delete");
                Close();
            }
            else
            {
                MessageBox.Show("Gagal");
            }
        }
    }
}
