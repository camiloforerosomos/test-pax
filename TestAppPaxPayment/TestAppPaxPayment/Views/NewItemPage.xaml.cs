using System;
using System.Collections.Generic;
using System.ComponentModel;
using TestAppPaxPayment.Models;
using TestAppPaxPayment.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestAppPaxPayment.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}