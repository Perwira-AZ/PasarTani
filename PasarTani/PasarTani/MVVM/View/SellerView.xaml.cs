﻿using Microsoft.Win32;
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

        // Experimental section ----------------------------------------------------------------------
        //Seller Page
/*        public event PropertyChangedEventHandler? PropertyChanged;

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

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            string imageurl = "";



            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));

                Trace.WriteLine(op.FileName);

                ItemServices itemServices = new ItemServices();

                imageurl = itemServices.GenerateUrlImage(op.FileName, SharedData.currentAccountLoginID + SharedData.currentAccountName);

                Trace.WriteLine(imageurl); // Store this url to postgreSQL


                ItemServices itemService = new ItemServices();

                //Init item
                Item item = itemService.GetItemById(1);

                Trace.WriteLine(item);

                //Change Image
                itemService.AddItem("New Image", 1, 10, 100, imageurl);

            }

        }*/

        // Experimental section ----------------------------------------------------------------------
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
