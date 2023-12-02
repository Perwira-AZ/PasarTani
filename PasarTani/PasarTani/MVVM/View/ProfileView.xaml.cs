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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasarTani.MVVM.View
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        public ProfileView()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnSaveProfile_Click(object sender, RoutedEventArgs e)
        {

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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(SharedData.isAccountSeller)
            {
/*                SellerServices sellerServices = new SellerServices();
                AddressServices addressServices = new AddressServices();


                Seller sellerProfile = sellerServices.GetSellerById(SharedData.currentAccountLoginID);

                txtName.Text = sellerProfile.Name;
                txtEmail.Text = sellerProfile.Email;
                txtPhone.Text = sellerProfile.PhoneNumber;
                passPassword.Password = sellerProfile.Password;
*/
                



                
            }
        }
    }
}
