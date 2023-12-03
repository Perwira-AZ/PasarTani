using PasarTani.Model;
using PasarTani.MVVM.Model;
using PasarTani.MVVM.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Trace.WriteLine($"ItemID: {((Item)DataContext).ItemID}, ItemName: {buyItemName.Text}, SellerID: {((Item)DataContext).SellerID},Price: {buyItemPrice.Text}, Stock: {buyItemStock.Text}, URL: {((Item)DataContext).ImageURL}, Description: {buyItemDesc.Text}");


            Trace.WriteLine(buyItemPrice.Text);
            Trace.WriteLine(buyItemStock.Text);
            //Stock: 800

            int quantity = int.Parse(buyQuantity.Text);

            ItemServices itemServices = new ItemServices();

            string imageUrl = itemServices.GenerateUrlImage(SharedData.temporaryImageFilePath, SharedData.currentAccountLoginID + SharedData.currentAccountName);

            bool status = itemServices.UpdateItem(((Item)DataContext).ItemID, buyItemName.Text, ((Item)DataContext).SellerID,  int.Parse(buyItemStock.Text)-quantity, int.Parse(buyItemPrice.Text), imageUrl, buyItemDesc.Text);

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
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UpdateQty(object sender, TextChangedEventArgs e)
        {
            if(buyQuantity.Text != "")
            {
                if (int.Parse(buyQuantity.Text) <= int.Parse(buyItemStock.Text))
                {
                    UpdateTotalPrice();
                }else{
                    buyQuantity.Text = buyItemStock.Text;
                    UpdateTotalPrice();
                }
            }
            else
            {
                UpdateTotalPrice();
            }
        }

        private void UpdateTotalPrice()
        {
            if(buyQuantity.Text != "")
            {
                TotalPrice.Text = $"Total: {int.Parse(buyItemPrice.Text) * int.Parse(buyQuantity.Text)}";
            }
            else
            {
                TotalPrice.Text = "Total: 0";
            }
        }
    }
}
