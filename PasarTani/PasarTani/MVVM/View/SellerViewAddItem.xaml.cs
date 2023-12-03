using Microsoft.Win32;
using PasarTani.Model;
using PasarTani.MVVM.Model;
using PasarTani.MVVM.Services;
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
using System.Windows.Shapes;
using Imagekit;
using System.Text.RegularExpressions;

namespace PasarTani.MVVM.View
{
    /// <summary>
    /// Interaction logic for SellerViewAddItem.xaml
    /// </summary>
    public partial class SellerViewAddItem : Window
    {
        public SellerViewAddItem()
        {
            InitializeComponent();
            this.DataContext = new SellerViewAddItemModel(); ;
        }

        private void btnOpenImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            string imageurl = "";



            if (op.ShowDialog() == true)
            {
                uploadImgPhoto.Source = new BitmapImage(new Uri(op.FileName));

                Trace.WriteLine(op.FileName);

                SharedData.temporaryImageFilePath = op.FileName;

/*                ItemServices itemServices = new ItemServices();

                imageurl = itemServices.GenerateUrlImage(op.FileName, SharedData.currentAccountLoginID + SharedData.currentAccountName);

                Trace.WriteLine(imageurl); // Store this url to postgreSQL

                SharedData.temporaryUploadImage = imageurl;*/

            }

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
