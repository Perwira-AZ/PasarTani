using Microsoft.Win32;
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
            Trace.WriteLine($"ItemID: {((Item)DataContext).ItemID}, ItemName: {detailItemName.Text}, SellerID: {((Item)DataContext).SellerID},Price: {detailItemPrice.Text}, Stock: {detailItemStock.Text}, URL: {((Item)DataContext).ImageURL}, Description: {detailItemDesc.Text}");
            
            
            Trace.WriteLine(detailItemPrice.Text);
            Trace.WriteLine(detailItemStock.Text);
            //Stock: 800
            //

            ItemServices itemServices = new ItemServices();


            string imageUrl = itemServices.GenerateUrlImage(SharedData.temporaryImageFilePath, SharedData.currentAccountLoginID.ToString());
            
            if (imageUrl == null)
            {
                imageUrl = ((Item)DataContext).ImageURL;
            }

            bool status = itemServices.UpdateItem(((Item)DataContext).ItemID, detailItemName.Text, ((Item)DataContext).SellerID, int.Parse(detailItemStock.Text), int.Parse(detailItemPrice.Text), imageUrl, detailItemDesc.Text);

            if(status)
            {
                MessageBox.Show("Berhasil Edit");
                Close();
                SharedData.temporaryImageFilePath = "";
                SharedData.temporaryUploadImage = "";
            }
            else
            {
                MessageBox.Show("Gagal");
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine($"ItemID: {((Item)DataContext).ItemID}, ItemName: {detailItemName.Text}, SellerID: {((Item)DataContext).SellerID},Price: {detailItemPrice.Text}, Stock: {detailItemStock.Text}, URL: {((Item)DataContext).ImageURL}, Description: {detailItemDesc.Text}");

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

        private void btnOpenEditImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";


            if (op.ShowDialog() == true)
            {
                EditImgPhoto.Source = new BitmapImage(new Uri(op.FileName));

                Trace.WriteLine(op.FileName);

                SharedData.temporaryImageFilePath = op.FileName;

                /*                ItemServices itemServices = new ItemServices();

                                imageurl = itemServices.GenerateUrlImage(op.FileName, SharedData.currentAccountLoginID + SharedData.currentAccountName);

                                Trace.WriteLine(imageurl); // Store this url to postgreSQL

                                SharedData.temporaryUploadImage = imageurl;*/

            }
        }
    }
}
