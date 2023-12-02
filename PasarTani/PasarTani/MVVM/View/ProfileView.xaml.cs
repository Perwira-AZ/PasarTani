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
            if(SharedData.isAccountSeller) 
            { 
                ItemServices itemServices = new ItemServices();
                AddressServices addressServices = new AddressServices();
                SellerServices sellerServices = new SellerServices();

                string imageurl = itemServices.GenerateUrlImage(SharedData.temporaryImageFilePath, SharedData.currentAccountLoginID + SharedData.currentAccountName);

                bool statusAddress = addressServices.UpdateAddressById(SharedData.currentAddressID, txtAddress.Text, txtCity.Text, txtProvince.Text);

                bool status = sellerServices.UpdateSeller(SharedData.currentAccountLoginID, txtName.Text, txtPhone.Text, txtEmail.Text, passPassword.Password, imageurl);

                if(statusAddress && status) 
                {
                    MessageBox.Show("Data Berhasil Disimpan");
                    SharedData.currentAccountName = txtName.Text;
                }
                else
                {
                    MessageBox.Show("Data gagal Disimpan");
                }

            }
            else
            {
                ItemServices itemServices = new ItemServices();
                AddressServices addressServices = new AddressServices();
                CustomerServices customerServices = new CustomerServices();

                string imageurl = itemServices.GenerateUrlImage(SharedData.temporaryImageFilePath, SharedData.currentAccountLoginID + SharedData.currentAccountName);

                bool statusAddress = addressServices.UpdateAddressById(SharedData.currentAddressID, txtAddress.Text, txtCity.Text, txtProvince.Text);

                bool status = customerServices.UpdateCustomer(SharedData.currentAccountLoginID, txtName.Text, txtPhone.Text, txtEmail.Text, passPassword.Password, imageurl);

                if (statusAddress && status)
                {
                    MessageBox.Show("Data Berhasil Disimpan");
                    SharedData.currentAccountName = txtName.Text;
                }
                else
                {
                    MessageBox.Show("Data gagal Disimpan");
                }
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
                EditImgPhoto.ImageSource = new BitmapImage(new Uri(op.FileName));

                Trace.WriteLine(op.FileName);

                SharedData.temporaryImageFilePath = op.FileName;
/*
                ItemServices itemServices = new ItemServices();

                string imageurl = itemServices.GenerateUrlImage(op.FileName, SharedData.currentAccountLoginID + SharedData.currentAccountName);

                Trace.WriteLine(imageurl); // Store this url to postgreSQL

                SharedData.temporaryUploadImage = imageurl;*/

            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(SharedData.isAccountSeller)
            {
                SellerServices sellerServices = new SellerServices();
                AddressServices addressServices = new AddressServices();



                Seller sellerProfile = sellerServices.GetSellerById(SharedData.currentAccountLoginID);
                SharedData.currentAddressID = sellerProfile.AddressId;
                Address address = addressServices.GetAddressById(SharedData.currentAddressID);

                txtName.Text = sellerProfile.Name;
                txtEmail.Text = sellerProfile.Email;
                txtPhone.Text = sellerProfile.PhoneNumber;
                passPassword.Password = sellerProfile.Password;
                txtAddress.Text = address.AddressName;
                txtCity.Text = address.City;
                txtProvince.Text = address.Province;
                string imageUrl = sellerProfile.ImageUrl;


                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(imageUrl);
                    bitmap.EndInit();
                    EditImgPhoto.ImageSource = bitmap;
                }
                catch
                {
                    EditImgPhoto.ImageSource = null;
                }


            }
            else
            {
                CustomerServices customerServices = new CustomerServices();
                AddressServices addressServices = new AddressServices();

                Customer customerProfile = customerServices.GetCustomerById(SharedData.currentAccountLoginID);
                SharedData.currentAddressID = customerProfile.AddressId;
                Address address = addressServices.GetAddressById(customerProfile.ID);

                txtName.Text = customerProfile.Name;
                txtEmail.Text = customerProfile.Email;
                txtPhone.Text = customerProfile.PhoneNumber;
                passPassword.Password = customerProfile.Password;
                txtAddress.Text = address.AddressName;
                txtCity.Text = address.City;
                txtProvince.Text = address.Province;
                string imageUrl = customerProfile.ImageUrl;

                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(imageUrl);
                    bitmap.EndInit();
                    EditImgPhoto.ImageSource = bitmap;
                }
                catch
                {
                    EditImgPhoto.ImageSource = null;
                }
            }
        }
    }
}
